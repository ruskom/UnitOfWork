using System;
using System.Data.Entity;
using UnitOfWork.Domain;

namespace UnitOfWork.Data.Entity
{
	public class ProfileDbContext : DbContext
	{
		public ProfileDbContext() : base("ProfileDbContext")
		{
			Configuration.LazyLoadingEnabled = false;
		}

		public DbSet<Profile> Profiles { get; set; }
	}
}