namespace BookStore.Infra.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UniqueType : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BookEntity", "Title", unique: true);
        }

        public override void Down()
        {
            DropIndex("dbo.BookEntity", new[] { "Title" });
        }
    }
}
