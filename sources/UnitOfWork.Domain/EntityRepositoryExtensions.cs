using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace UnitOfWork.Domain
{
	public static class EntityRepositoryExtensions
	{
		public static async Task<TEntity> DeleteAsync<TEntity, TId>([NotNull] this IEntityRepository<TEntity, TId> entityRepository, TId id) where TEntity : class, IEntity<TId>
		{
			if (entityRepository == null)
			{
				throw new ArgumentNullException("entityRepository");
			}

			var value = await entityRepository.GetByIdAsync(id);
			if (value == null)
			{
				return null;
			}

			entityRepository.Delete(value);
			return value;
		}
	}
}