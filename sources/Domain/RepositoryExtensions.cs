using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace UnitOfWork.Domain
{
	public static class RepositoryExtensions
	{
		public static async Task<TEntity> DeleteAsync<TEntity, TId>([NotNull] this IRepository<TEntity, TId> repository, TId id) where TEntity : Entity<TId>
		{
			if (repository == null)
			{
				throw new ArgumentNullException(nameof(repository));
			}

			var item = await repository.GetByIdAsync(id);
			if (item == null)
			{
				return null;
			}

			return repository.Delete(item);
		}
	}
}