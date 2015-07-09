using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace UnitOfWork.Domain
{
	public static class EntityRepositoryExtensions
	{
		public static async Task<TEntity> DeleteAsync<TEntity, TId>([NotNull] this IEntityRepository<TEntity, TId> repository, TId id) where TEntity : class, IEntity<TId>
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}

			var value = await repository.GetByIdAsync(id);
			if (value == null)
			{
				return null;
			}

			repository.Delete(value);
			return value;
		}
	}
}