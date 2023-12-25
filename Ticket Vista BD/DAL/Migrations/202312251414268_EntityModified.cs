namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityModified : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AdminProfiles", newName: "Admins");
            RenameTable(name: "dbo.AdvertiserProfiles", newName: "Advertisers");
            RenameTable(name: "dbo.BuyerProfiles", newName: "Buyers");
            RenameTable(name: "dbo.EmployeeProfiles", newName: "Employees");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Employees", newName: "EmployeeProfiles");
            RenameTable(name: "dbo.Buyers", newName: "BuyerProfiles");
            RenameTable(name: "dbo.Advertisers", newName: "AdvertiserProfiles");
            RenameTable(name: "dbo.Admins", newName: "AdminProfiles");
        }
    }
}
