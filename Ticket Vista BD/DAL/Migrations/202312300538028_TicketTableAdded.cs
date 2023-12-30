namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketTableAdded : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropForeignKey("dbo.Tickets", "BuyerId", "dbo.Buyers");
            DropIndex("dbo.Tickets", new[] { "BuyerId" });
            DropIndex("dbo.Tickets", new[] { "EventId" });
            DropTable("dbo.Tickets");
        }
    }
}
