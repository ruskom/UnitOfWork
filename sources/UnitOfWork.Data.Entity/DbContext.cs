using System;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnitOfWork.Domain;

namespace UnitOfWork.Data.Entity
{
    public abstract class DbContext : System.Data.Entity.DbContext
    {
        protected DbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public override int SaveChanges()
        {
            UpdateChangeTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            UpdateChangeTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateChangeTimestamps()
        {
            var now = DateTime.Now;

            foreach (var item in GetEntitiesByState(EntityState.Added).OfType<IHasChangeTimestamps>())
            {
                item.CreatedAt = now;
                item.LastUpdatedAt = now;
            }

            foreach (var item in GetEntitiesByState(EntityState.Modified).OfType<IHasChangeTimestamps>())
            {
                item.LastUpdatedAt = now;
            }
        }

        private IEnumerable GetEntitiesByState(EntityState entityState)
            =>
                (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(entityState).
                    Where(entry => !entry.IsRelationship).
                    Select(entry => entry.Entity);
    }
}