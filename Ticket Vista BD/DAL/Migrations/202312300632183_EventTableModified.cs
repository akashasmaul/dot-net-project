namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventTableModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "AdvertiseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "AdvertiseId");
            AddForeignKey("dbo.Events", "AdvertiseId", "dbo.Advertises", "Id", cascadeDelete: true);
            DropColumn("dbo.Events", "Advertiser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Advertiser", c => c.String());
            DropForeignKey("dbo.Events", "AdvertiseId", "dbo.Advertises");
            DropIndex("dbo.Events", new[] { "AdvertiseId" });
            DropColumn("dbo.Events", "AdvertiseId");
        }
    }
}
