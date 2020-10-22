namespace FootBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreationofDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "Content", c => c.String(nullable: false));
            DropColumn("dbo.Post", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "Text", c => c.String(nullable: false));
            DropColumn("dbo.Post", "Content");
        }
    }
}
