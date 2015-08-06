using System;
using JetBrains.Annotations;
using UnitOfWork.Data;
using UnitOfWork.Data.Entity;

namespace UnitOfWork.Sample.Data.Entity
{
	public class ProfileUnitOfWorkFactory : IUnitOfWorkFactory<IProfileUnitOfWork>
	{
		public ProfileUnitOfWorkFactory([NotNull] IDbContextFactory<ProfileDbContext> dbContextFactory)
		{
			if (dbContextFactory == null)
			{
				throw new ArgumentNullException(nameof(dbContextFactory));
			}

			DbContextFactory = dbContextFactory;
		}

		private IDbContextFactory<ProfileDbContext> DbContextFactory { get; }

		public IProfileUnitOfWork Create() => new ProfileUnitOfWork(DbContextFactory);
	}
}