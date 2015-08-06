using System;
using System.Data.Entity;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnitOfWork.Domain;

namespace UnitOfWork.Data.Entity
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        protected Repository([NotNull] IDbSet<TEntity> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            Items = items;
        }

        protected IDbSet<TEntity> Items { get; set; }

        public virtual Task<TEntity> GetByIdAsync(TId id) => Task.FromResult(Items.Find(id));
        public TEntity Insert(TEntity item) => Items.Add(item);
        public TEntity Update(TEntity item) => item;
        public TEntity Delete(TEntity item) => Items.Remove(item);
    }
}