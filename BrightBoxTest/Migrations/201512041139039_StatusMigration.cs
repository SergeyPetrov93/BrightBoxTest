namespace BrightBoxTest.Models
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class StatusMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    StatusKey = c.Byte(nullable: false),
                    WorkDateTime = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Status");
        }
    }
}
