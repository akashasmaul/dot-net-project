namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateRemovedEvent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
        }
    }
}
