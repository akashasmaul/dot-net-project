namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableModifiedWithTicketPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertises", "TicketPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertises", "TicketPrice");
        }
    }
}
