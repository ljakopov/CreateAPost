namespace CreateAPost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFriendshipsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        FriendUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.FriendUserId })
                .ForeignKey("dbo.AspNetUsers", t => t.FriendUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.FriendUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friendships", "FriendUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Friendships", new[] { "FriendUserId" });
            DropIndex("dbo.Friendships", new[] { "ApplicationUserId" });
            DropTable("dbo.Friendships");
        }
    }
}
