using System;
using System.Data.Entity.ModelConfiguration;
using UnitOfWork.Domain;

namespace UnitOfWork.Data.Entity
{
    public abstract class EntityTypeConfiguration<TEntity, TId> : EntityTypeConfiguration<TEntity> where TEntity : Entity<TId>
    {
        protected EntityTypeConfiguration()
        {
            Property(entity => entity.CreatedAt);
            Property(entity => entity.LastUpdatedAt);
        }
    }
}