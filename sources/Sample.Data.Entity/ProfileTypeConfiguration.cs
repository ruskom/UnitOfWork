using System;
using UnitOfWork.Data.Entity;
using UnitOfWork.Sample.Domain;

namespace UnitOfWork.Sample.Data.Entity
{
	public class ProfileTypeConfiguration : EntityTypeConfiguration<Profile, int>
	{
		public ProfileTypeConfiguration()
		{
			Property(profile => profile.Name);
		}
	}
}