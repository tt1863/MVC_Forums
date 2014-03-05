namespace MVC_Forums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Thread_ThreadId", "dbo.Threads");
            DropIndex("dbo.Posts", new[] { "Thread_ThreadId" });
            RenameColumn(table: "dbo.Posts", name: "Thread_ThreadId", newName: "ThreadId");
            AlterColumn("dbo.Posts", "ThreadId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "ThreadId");
            AddForeignKey("dbo.Posts", "ThreadId", "dbo.Threads", "ThreadId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "ThreadId", "dbo.Threads");
            DropIndex("dbo.Posts", new[] { "ThreadId" });
            AlterColumn("dbo.Posts", "ThreadId", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "ThreadId", newName: "Thread_ThreadId");
            CreateIndex("dbo.Posts", "Thread_ThreadId");
            AddForeignKey("dbo.Posts", "Thread_ThreadId", "dbo.Threads", "ThreadId");
        }
    }
}
