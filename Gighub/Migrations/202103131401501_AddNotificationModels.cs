namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotificationModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        OriginalDateTime = c.DateTime(),
                        OriginalVenue = c.String(),
                        Gig_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gigs", t => t.Gig_Id, cascadeDelete: true)
                .Index(t => t.Gig_Id);
            
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        notificationId = c.Int(nullable: false),
                        isRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.notificationId })
                .ForeignKey("dbo.Notifications", t => t.notificationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.notificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotifications", "notificationId", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "Gig_Id", "dbo.Gigs");
            DropIndex("dbo.UserNotifications", new[] { "notificationId" });
            DropIndex("dbo.UserNotifications", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "Gig_Id" });
            DropTable("dbo.UserNotifications");
            DropTable("dbo.Notifications");
        }
    }
}
