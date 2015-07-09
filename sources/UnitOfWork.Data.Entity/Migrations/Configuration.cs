using System;
using System.Data.Entity.Migrations;

namespace UnitOfWork.Data.Entity.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<ProfileDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}
	}
}