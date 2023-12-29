namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdvertiseModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertises", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertises", "Status");
        }
    }
}
