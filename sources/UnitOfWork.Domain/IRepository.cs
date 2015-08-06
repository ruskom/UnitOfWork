using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace UnitOfWork.Domain
{
	// TODO: to data.core?
	public interface IRepository<TEntity, in TId> where TEntity : Entity<TId>
	{
		Task<TEntity> GetByIdAsync(TId id);
		TEntity Insert([NotNull] TEntity item);
		TEntity Update([NotNull] TEntity item);
		TEntity Delete([NotNull] TEntity item);
	}
}