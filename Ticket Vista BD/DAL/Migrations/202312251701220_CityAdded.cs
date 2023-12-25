namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CityAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "City", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Advertisers", "City", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Buyers", "City", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Employees", "City", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Buyers", "City");
            DropColumn("dbo.Advertisers", "City");
            DropColumn("dbo.Admins", "City");
        }
    }
}
