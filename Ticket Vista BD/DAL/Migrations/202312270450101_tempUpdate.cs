namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tempUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tokens", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tokens", "UserId");
        }
    }
}
