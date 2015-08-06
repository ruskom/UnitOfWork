using System;
using System.Data.Entity.Migrations;

namespace UnitOfWork.Sample.Data.Entity.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<ProfileDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}
	}
}