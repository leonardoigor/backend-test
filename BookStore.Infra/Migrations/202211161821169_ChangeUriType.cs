namespace BookStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUriType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookEntity", "ThumbnailUrl", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookEntity", "ThumbnailUrl");
        }
    }
}
