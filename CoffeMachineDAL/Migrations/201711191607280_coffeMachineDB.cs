namespace CoffeMachineDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coffeMachineDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SugarQuantity = c.Int(nullable: false),
                        SelfMug = c.Boolean(nullable: false),
                        OrderTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderTypes", t => t.OrderTypeId, cascadeDelete: true)
                .Index(t => t.UserId, unique: true)
                .Index(t => t.OrderTypeId);
            
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Label, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderTypeId", "dbo.OrderTypes");
            DropIndex("dbo.OrderTypes", new[] { "Label" });
            DropIndex("dbo.Orders", new[] { "OrderTypeId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropTable("dbo.OrderTypes");
            DropTable("dbo.Orders");
        }
    }
}
