namespace Market_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_cato : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.products", "img", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.products", "img", c => c.String(nullable: false));
        }
    }
}
