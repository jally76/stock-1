namespace Stock.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration0001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128, unicode: false),
                        StockCode = c.String(nullable: false, maxLength: 32, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 254, unicode: false),
                        Name = c.String(nullable: false, maxLength: 128, unicode: false),
                        Password = c.String(nullable: false, maxLength: 48, unicode: false),
                        Salt = c.String(nullable: false, maxLength: 24, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTickers",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CompanyId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTickers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.UserTickers", "UserId", "dbo.Users");
            DropIndex("dbo.UserTickers", new[] { "CompanyId" });
            DropIndex("dbo.UserTickers", new[] { "UserId" });
            DropTable("dbo.UserTickers");
            DropTable("dbo.Users");
            DropTable("dbo.Companies");
        }
    }
}
