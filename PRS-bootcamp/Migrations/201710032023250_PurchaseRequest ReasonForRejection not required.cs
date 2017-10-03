namespace PRS_bootcamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseRequestReasonForRejectionnotrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequests", "ReasonForRejection", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequests", "ReasonForRejection", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
