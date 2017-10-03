namespace PRS_bootcamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductVendorPartNumbermadeunique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "VendorId" });
            CreateIndex("dbo.Products", new[] { "VendorId", "VendorPartNumber" }, unique: true, name: "IX_VendorPartNumber");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", "IX_VendorPartNumber");
            CreateIndex("dbo.Products", "VendorId");
        }
    }
}
