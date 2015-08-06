using System;
using System.Threading;
using JetBrains.Annotations;
using UnitOfWork.Domain;

namespace UnitOfWork.Data.Entity
{
    public class ProfileUnitOfWork : UnitOfWork<ProfileDbContext>, IProfileUnitOfWork
    {
        private Lazy<IProfileRepository> ProfileRepository { get; }

        public ProfileUnitOfWork([NotNull] IDbContextFactory<ProfileDbContext> dbContextFactory) : base(dbContextFactory)
        {
            ProfileRepository = new Lazy<IProfileRepository>(() => new ProfileRepository(DbContext.Profiles), LazyThreadSafetyMode.None);
        }

        public IProfileRepository Profiles => ProfileRepository.Value;
    }
}