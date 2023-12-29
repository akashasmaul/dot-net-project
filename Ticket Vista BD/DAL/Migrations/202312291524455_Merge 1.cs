namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Merge1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Advertiser = c.String(),
                        EmpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmpId, cascadeDelete: true)
                .Index(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EmpId", "dbo.Employees");
            DropIndex("dbo.Events", new[] { "EmpId" });
            DropTable("dbo.Events");
        }
    }
}
