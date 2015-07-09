using System;
using UnitOfWork.Domain;

namespace UnitOfWork.Data.Entity
{
	public class ProfileUnitOfWork : UnitOfWork<ProfileDbContext>, IProfileUnitOfWork
	{
		public IProfileRepository Profiles
		{
			get
			{
				return new ProfileRepository(DbContext.Profiles);
			}
		}
	}
}