namespace PRS_bootcamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageFKtest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(),
                        ReceiverId = c.Int(),
                        Text = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ReceiverId)
                .ForeignKey("dbo.Users", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            AddColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AddColumn("dbo.PurchaseRequestLineItems", "IsFulfilled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Messages", "ReceiverId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "ReceiverId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropColumn("dbo.PurchaseRequestLineItems", "IsFulfilled");
            DropColumn("dbo.Products", "Description");
            DropTable("dbo.Messages");
        }
    }
}
