using BookStore.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookStore.Infra.Persistence;

public class BookContext : DbContext
{
    public BookContext() : base(@"Server=.\sqlexpress; Database=BookStore;Trusted_Connection=True;")
    {
    }

    public DbSet<BookEntity> Books { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //Remove the pluralization of table names
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //Remove cascading delete
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        //Set to use varchar or instead of nvarchar
        modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));


        //If I forget to inform the field size, it will put a varchar of 100
        modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));


        #region Add Entity auto-map by assembly

        modelBuilder.Configurations.AddFromAssembly(typeof(BookContext).Assembly);

        #endregion

        modelBuilder.Entity<BookEntity>().HasIndex(a => a.Title).IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
