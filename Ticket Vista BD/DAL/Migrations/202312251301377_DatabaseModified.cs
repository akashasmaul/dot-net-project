namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdminProfiles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AdvertiserProfiles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BuyerProfiles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.EmployeeProfiles", "User_Id", "dbo.Users");
            DropIndex("dbo.AdminProfiles", new[] { "User_Id" });
            DropIndex("dbo.AdvertiserProfiles", new[] { "User_Id" });
            DropIndex("dbo.BuyerProfiles", new[] { "User_Id" });
            DropIndex("dbo.EmployeeProfiles", new[] { "User_Id" });
            AddColumn("dbo.AdminProfiles", "UserName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.AdminProfiles", "Password", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.AdvertiserProfiles", "UserName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.AdvertiserProfiles", "Password", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.BuyerProfiles", "UserName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.BuyerProfiles", "Password", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.EmployeeProfiles", "UserName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.EmployeeProfiles", "Password", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.AdminProfiles", "User_Id");
            DropColumn("dbo.AdvertiserProfiles", "User_Id");
            DropColumn("dbo.BuyerProfiles", "User_Id");
            DropColumn("dbo.EmployeeProfiles", "User_Id");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.EmployeeProfiles", "User_Id", c => c.Int(nullable: false));
            AddColumn("dbo.BuyerProfiles", "User_Id", c => c.Int(nullable: false));
            AddColumn("dbo.AdvertiserProfiles", "User_Id", c => c.Int(nullable: false));
            AddColumn("dbo.AdminProfiles", "User_Id", c => c.Int(nullable: false));
            DropColumn("dbo.EmployeeProfiles", "Password");
            DropColumn("dbo.EmployeeProfiles", "UserName");
            DropColumn("dbo.BuyerProfiles", "Password");
            DropColumn("dbo.BuyerProfiles", "UserName");
            DropColumn("dbo.AdvertiserProfiles", "Password");
            DropColumn("dbo.AdvertiserProfiles", "UserName");
            DropColumn("dbo.AdminProfiles", "Password");
            DropColumn("dbo.AdminProfiles", "UserName");
            CreateIndex("dbo.EmployeeProfiles", "User_Id");
            CreateIndex("dbo.BuyerProfiles", "User_Id");
            CreateIndex("dbo.AdvertiserProfiles", "User_Id");
            CreateIndex("dbo.AdminProfiles", "User_Id");
            AddForeignKey("dbo.EmployeeProfiles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BuyerProfiles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdvertiserProfiles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdminProfiles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
