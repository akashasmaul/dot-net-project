namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Advertisers", "FK__Advertise__Adver__160F4887");
            DropColumn("dbo.Advertisers", "AdvertiseId");
        }

        public override void Down()
        {
            AddColumn("dbo.Advertisers", "AdvertiseId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Advertisers", "FK__Advertise__Adver__160F4887", "dbo.Advertises", "AdvertiseId", cascadeDelete: true);
        }

    }
}
