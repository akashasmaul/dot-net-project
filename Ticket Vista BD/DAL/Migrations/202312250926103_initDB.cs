namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Nationality = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        SalId = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salaries", t => t.SalId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.SalId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false, maxLength: 20),
                        SalaryAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.AdvertiserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Nationality = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        AdvertiseId = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertises", t => t.AdvertiseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.AdvertiseId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Advertises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BuyerProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Nationality = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.EmployeeProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Nationality = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        SalId = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salaries", t => t.SalId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.SalId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        Type = c.String(nullable: false),
                        Username = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeProfiles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.EmployeeProfiles", "SalId", "dbo.Salaries");
            DropForeignKey("dbo.BuyerProfiles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AdvertiserProfiles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AdvertiserProfiles", "AdvertiseId", "dbo.Advertises");
            DropForeignKey("dbo.AdminProfiles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AdminProfiles", "SalId", "dbo.Salaries");
            DropIndex("dbo.EmployeeProfiles", new[] { "User_Id" });
            DropIndex("dbo.EmployeeProfiles", new[] { "SalId" });
            DropIndex("dbo.BuyerProfiles", new[] { "User_Id" });
            DropIndex("dbo.AdvertiserProfiles", new[] { "User_Id" });
            DropIndex("dbo.AdvertiserProfiles", new[] { "AdvertiseId" });
            DropIndex("dbo.AdminProfiles", new[] { "User_Id" });
            DropIndex("dbo.AdminProfiles", new[] { "SalId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.EmployeeProfiles");
            DropTable("dbo.BuyerProfiles");
            DropTable("dbo.Advertises");
            DropTable("dbo.AdvertiserProfiles");
            DropTable("dbo.Users");
            DropTable("dbo.Salaries");
            DropTable("dbo.AdminProfiles");
        }
    }
}
