namespace Market_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_cat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categroys",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        quntity = c.Int(nullable: false),
                        price = c.Single(nullable: false),
                        img = c.String(nullable: false),
                        categroyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categroys", t => t.categroyId, cascadeDelete: true)
                .Index(t => t.categroyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "categroyId", "dbo.categroys");
            DropIndex("dbo.products", new[] { "categroyId" });
            DropTable("dbo.products");
            DropTable("dbo.categroys");
        }
    }
}
