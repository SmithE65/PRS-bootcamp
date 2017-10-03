namespace PRS_bootcamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorCodemadeunique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Vendors", "Code", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vendors", new[] { "Code" });
        }
    }
}
