namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdvertiserAdvertises", "AdvertiseId", "dbo.Advertises");
            DropForeignKey("dbo.AdvertiserAdvertises", "AdvertiserId", "dbo.Advertisers");
            DropIndex("dbo.AdvertiserAdvertises", new[] { "AdvertiserId" });
            DropIndex("dbo.AdvertiserAdvertises", new[] { "AdvertiseId" });
            AddColumn("dbo.Advertises", "AdvertiserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Advertises", "Description", c => c.String());
            CreateIndex("dbo.Advertises", "AdvertiserId");
            AddForeignKey("dbo.Advertises", "AdvertiserId", "dbo.Advertisers", "Id", cascadeDelete: true);
            DropTable("dbo.AdvertiserAdvertises");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdvertiserAdvertises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdvertiserId = c.Int(nullable: false),
                        AdvertiseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Advertises", "AdvertiserId", "dbo.Advertisers");
            DropIndex("dbo.Advertises", new[] { "AdvertiserId" });
            AlterColumn("dbo.Advertises", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Advertises", "AdvertiserId");
            CreateIndex("dbo.AdvertiserAdvertises", "AdvertiseId");
            CreateIndex("dbo.AdvertiserAdvertises", "AdvertiserId");
            AddForeignKey("dbo.AdvertiserAdvertises", "AdvertiserId", "dbo.Advertisers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdvertiserAdvertises", "AdvertiseId", "dbo.Advertises", "Id", cascadeDelete: true);
        }
    }
}
