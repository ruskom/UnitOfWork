using System;
using System.Data.Entity;
using UnitOfWork.Sample.Domain;
using DbContext = UnitOfWork.Data.Entity.DbContext;

namespace UnitOfWork.Sample.Data.Entity
{
	public class ProfileDbContext : DbContext
	{
		public ProfileDbContext() : base("ProfileDbContext")
		{
		}

		public DbSet<Profile> Profiles { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Configurations.Add(new ProfileTypeConfiguration());
		}
	}
}