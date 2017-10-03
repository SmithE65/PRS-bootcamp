namespace PRS_bootcamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductPhotopathnotrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Photopath", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Photopath", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
