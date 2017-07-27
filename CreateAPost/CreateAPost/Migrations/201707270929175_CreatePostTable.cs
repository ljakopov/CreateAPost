namespace CreateAPost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePostTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 255),
                        UserId = c.String(nullable: false, maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropTable("dbo.Posts");
        }
    }
}
