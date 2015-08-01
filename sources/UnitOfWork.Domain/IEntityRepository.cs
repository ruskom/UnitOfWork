using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace UnitOfWork.Domain
{
	// TODO: IRepository instead
	public interface IEntityRepository<TEntity, in TId> where TEntity : class, IEntity<TId>
	{
		Task<TEntity> GetByIdAsync(TId id);
		TEntity Insert([NotNull] TEntity value);
		TEntity Update([NotNull] TEntity value);
		TEntity Delete([NotNull] TEntity value);
	}
}