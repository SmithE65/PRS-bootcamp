namespace PRS_bootcamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUserNamemadeunique : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Vendors", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Status", "User_Id", "dbo.Users");
            DropIndex("dbo.Products", new[] { "User_Id" });
            DropIndex("dbo.Vendors", new[] { "User_Id" });
            DropIndex("dbo.Status", new[] { "User_Id" });
            CreateIndex("dbo.Users", "UserName", unique: true);
            DropColumn("dbo.Products", "IsActive");
            DropColumn("dbo.Products", "DateCreated");
            DropColumn("dbo.Products", "DateUpdated");
            DropColumn("dbo.Products", "UpdatedByUser");
            DropColumn("dbo.Products", "User_Id");
            DropColumn("dbo.Vendors", "IsActive");
            DropColumn("dbo.Vendors", "DateCreated");
            DropColumn("dbo.Vendors", "DateUpdated");
            DropColumn("dbo.Vendors", "UpdatedByUser");
            DropColumn("dbo.Vendors", "User_Id");
            DropColumn("dbo.PurchaseRequests", "IsActive");
            DropColumn("dbo.PurchaseRequests", "DateCreated");
            DropColumn("dbo.PurchaseRequests", "DateUpdated");
            DropColumn("dbo.PurchaseRequests", "UpdatedByUser");
            DropColumn("dbo.Status", "IsActive");
            DropColumn("dbo.Status", "DateCreated");
            DropColumn("dbo.Status", "DateUpdated");
            DropColumn("dbo.Status", "UpdatedByUser");
            DropColumn("dbo.Status", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Status", "User_Id", c => c.Int());
            AddColumn("dbo.Status", "UpdatedByUser", c => c.Int());
            AddColumn("dbo.Status", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Status", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Status", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.PurchaseRequests", "UpdatedByUser", c => c.Int());
            AddColumn("dbo.PurchaseRequests", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseRequests", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseRequests", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vendors", "User_Id", c => c.Int());
            AddColumn("dbo.Vendors", "UpdatedByUser", c => c.Int());
            AddColumn("dbo.Vendors", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vendors", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vendors", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "User_Id", c => c.Int());
            AddColumn("dbo.Products", "UpdatedByUser", c => c.Int());
            AddColumn("dbo.Products", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
            DropIndex("dbo.Users", new[] { "UserName" });
            CreateIndex("dbo.Status", "User_Id");
            CreateIndex("dbo.Vendors", "User_Id");
            CreateIndex("dbo.Products", "User_Id");
            AddForeignKey("dbo.Status", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Vendors", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Products", "User_Id", "dbo.Users", "Id");
        }
    }
}
