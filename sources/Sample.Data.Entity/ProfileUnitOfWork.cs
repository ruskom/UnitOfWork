using System;
using System.Threading;
using JetBrains.Annotations;
using UnitOfWork.Data.Entity;
using UnitOfWork.Sample.Domain;

namespace UnitOfWork.Sample.Data.Entity
{
	public class ProfileUnitOfWork : UnitOfWork<ProfileDbContext>, IProfileUnitOfWork
	{
		public ProfileUnitOfWork([NotNull] IDbContextFactory<ProfileDbContext> dbContextFactory) : base(dbContextFactory)
		{
			ProfileRepository = new Lazy<IProfileRepository>(() => new ProfileRepository(DbContext.Profiles), LazyThreadSafetyMode.None);
		}

		private Lazy<IProfileRepository> ProfileRepository { get; }

		public IProfileRepository Profiles => ProfileRepository.Value;
	}
}