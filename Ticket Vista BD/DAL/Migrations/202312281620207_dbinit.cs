namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Nationality = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        SalId = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salaries", t => t.SalId, cascadeDelete: true)
                .Index(t => t.SalId);
            
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
            
            CreateTable(
                "dbo.Advertises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        TicketPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Advertisers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Nationality = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        City = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Nationality = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        City = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Nationality = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        SalId = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salaries", t => t.SalId, cascadeDelete: true)
                .Index(t => t.SalId);
            
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SalId", "dbo.Salaries");
            DropForeignKey("dbo.AdvertiserAdvertises", "AdvertiserId", "dbo.Advertisers");
            DropForeignKey("dbo.AdvertiserAdvertises", "AdvertiseId", "dbo.Advertises");
            DropForeignKey("dbo.Admins", "SalId", "dbo.Salaries");
            DropIndex("dbo.Employees", new[] { "SalId" });
            DropIndex("dbo.AdvertiserAdvertises", new[] { "AdvertiseId" });
            DropIndex("dbo.AdvertiserAdvertises", new[] { "AdvertiserId" });
            DropIndex("dbo.Admins", new[] { "SalId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Employees");
            DropTable("dbo.Buyers");
            DropTable("dbo.Advertisers");
            DropTable("dbo.Advertises");
            DropTable("dbo.AdvertiserAdvertises");
            DropTable("dbo.Salaries");
            DropTable("dbo.Admins");
        }
    }
}
