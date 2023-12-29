namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class advertisetablemodifiedTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertises", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertises", "Title");
        }
    }
}
