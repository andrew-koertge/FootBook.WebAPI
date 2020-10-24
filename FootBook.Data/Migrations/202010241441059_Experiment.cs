namespace FootBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Experiment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "UserId", "dbo.Author");
            DropIndex("dbo.Post", new[] { "UserId" });
            AddColumn("dbo.Post", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Post", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Post", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Post", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Post", "ModifiedUtc");
            DropColumn("dbo.Post", "CreatedUtc");
            DropColumn("dbo.Post", "OwnerId");
            CreateIndex("dbo.Post", "UserId");
            AddForeignKey("dbo.Post", "UserId", "dbo.Author", "UserId", cascadeDelete: true);
        }
    }
}
