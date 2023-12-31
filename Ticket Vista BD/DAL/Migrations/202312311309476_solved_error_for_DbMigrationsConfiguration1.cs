namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class solved_error_for_DbMigrationsConfiguration1 : DbMigration
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
                "dbo.Advertises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdvertiserId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        TicketPrice = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertisers", t => t.AdvertiserId, cascadeDelete: true)
                .Index(t => t.AdvertiserId);
            
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
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        TicketPrice = c.Int(nullable: false),
                        AdvertiseId = c.Int(nullable: false),
                        EmpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertises", t => t.AdvertiseId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmpId, cascadeDelete: true)
                .Index(t => t.AdvertiseId)
                .Index(t => t.EmpId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        TicketQuantity = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.BuyerId);
            
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
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropForeignKey("dbo.Tickets", "BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.Events", "EmpId", "dbo.Employees");
            DropForeignKey("dbo.Events", "AdvertiseId", "dbo.Advertises");
            DropForeignKey("dbo.Employees", "SalId", "dbo.Salaries");
            DropForeignKey("dbo.Advertises", "AdvertiserId", "dbo.Advertisers");
            DropForeignKey("dbo.Admins", "SalId", "dbo.Salaries");
            DropIndex("dbo.Tickets", new[] { "BuyerId" });
            DropIndex("dbo.Tickets", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "EmpId" });
            DropIndex("dbo.Events", new[] { "AdvertiseId" });
            DropIndex("dbo.Employees", new[] { "SalId" });
            DropIndex("dbo.Advertises", new[] { "AdvertiserId" });
            DropIndex("dbo.Admins", new[] { "SalId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Tickets");
            DropTable("dbo.Events");
            DropTable("dbo.Employees");
            DropTable("dbo.Buyers");
            DropTable("dbo.Advertises");
            DropTable("dbo.Advertisers");
            DropTable("dbo.Salaries");
            DropTable("dbo.Admins");
        }
    }
}
