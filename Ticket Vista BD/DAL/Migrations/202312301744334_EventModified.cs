namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "TicketPrice", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Events", "TicketPrice");
        }
    }
}
