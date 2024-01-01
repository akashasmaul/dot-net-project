namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventTbaleForingeKeyOfSponsor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "SpnId", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "Sponsor_Id", c => c.Int());
            CreateIndex("dbo.Events", "Sponsor_Id");
            AddForeignKey("dbo.Events", "Sponsor_Id", "dbo.Sponsors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Sponsor_Id", "dbo.Sponsors");
            DropIndex("dbo.Events", new[] { "Sponsor_Id" });
            DropColumn("dbo.Events", "Sponsor_Id");
            DropColumn("dbo.Events", "SpnId");
        }
    }
}
