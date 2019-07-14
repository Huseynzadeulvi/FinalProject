namespace JobProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKUserToElan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Elans", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Elans", "UserId");
            AddForeignKey("dbo.Elans", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Elans", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Elans", new[] { "UserId" });
            DropColumn("dbo.Elans", "UserId");
        }
    }
}
