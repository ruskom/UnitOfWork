using System;
using System.Data.Entity.Migrations;

namespace UnitOfWork.Sample.Data.Entity.Migrations
{
	public partial class Initial : DbMigration
	{
		public override void Up()
		{
			CreateTable("dbo.Profiles", c => new { Id = c.Int(false, true), Name = c.String(), CreatedAt = c.DateTime(false), LastUpdatedAt = c.DateTime(false) }).PrimaryKey(t => t.Id);
		}

		public override void Down()
		{
			DropTable("dbo.Profiles");
		}
	}
}