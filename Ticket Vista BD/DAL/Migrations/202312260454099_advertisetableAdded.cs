namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class advertisetableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Advertises");
        }
    }
}
