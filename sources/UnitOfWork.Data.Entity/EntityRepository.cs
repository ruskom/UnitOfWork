using System;
using System.Data.Entity;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnitOfWork.Domain;

namespace UnitOfWork.Data.Entity
{
	// TODo: repository for non-entities
	public abstract class EntityRepository<TEntity, TId> : IEntityRepository<TEntity, TId> where TEntity : class, IEntity<TId>
	{
		protected IDbSet<TEntity> Values { get; set; }

		protected EntityRepository([NotNull] IDbSet<TEntity> values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}

			Values = values;
		}

		public virtual Task<TEntity> GetByIdAsync(TId id)
		{

		}

		public TEntity Insert(TEntity value)
		{
			value.CreatedAt = DateTime.Now;
			value.LastUpdateAt = value.CreatedAt;
			return Values.Add(value);
		}

		public TEntity Update(TEntity value)
		{
			value.LastUpdateAt = DateTime.Now;
			return value;
		}

		public TEntity Delete(TEntity value)
		{
			return Values.Remove(value);
		}
	}
}