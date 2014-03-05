namespace MVC_Forums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forums",
                c => new
                    {
                        ForumId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Sequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ForumId);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        ThreadId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ForumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ThreadId)
                .ForeignKey("dbo.Forums", t => t.ForumId, cascadeDelete: true)
                .Index(t => t.ForumId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Thread_ThreadId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Threads", t => t.Thread_ThreadId)
                .Index(t => t.Thread_ThreadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Thread_ThreadId", "dbo.Threads");
            DropForeignKey("dbo.Threads", "ForumId", "dbo.Forums");
            DropIndex("dbo.Posts", new[] { "Thread_ThreadId" });
            DropIndex("dbo.Threads", new[] { "ForumId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Threads");
            DropTable("dbo.Forums");
        }
    }
}
