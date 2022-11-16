namespace BookStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookEntity",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 100, unicode: false),
                        PublishedDate = c.String(maxLength: 100, unicode: false),
                        ShortDescription = c.String(maxLength: 100, unicode: false),
                        LongDescription = c.String(maxLength: 100, unicode: false),
                        Status = c.String(maxLength: 100, unicode: false),
                        Authors = c.String(maxLength: 100, unicode: false),
                        Categories = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookEntity");
        }
    }
}
