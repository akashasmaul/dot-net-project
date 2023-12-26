namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class advertiseradvertiseAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertiserAdvertises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdvertiserId = c.Int(nullable: false),
                        AdvertiseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertises", t => t.AdvertiseId, cascadeDelete: true)
                .ForeignKey("dbo.Advertisers", t => t.AdvertiserId, cascadeDelete: true)
                .Index(t => t.AdvertiserId)
                .Index(t => t.AdvertiseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertiserAdvertises", "AdvertiserId", "dbo.Advertisers");
            DropForeignKey("dbo.AdvertiserAdvertises", "AdvertiseId", "dbo.Advertises");
            DropIndex("dbo.AdvertiserAdvertises", new[] { "AdvertiseId" });
            DropIndex("dbo.AdvertiserAdvertises", new[] { "AdvertiserId" });
            DropTable("dbo.AdvertiserAdvertises");
        }
    }
}
