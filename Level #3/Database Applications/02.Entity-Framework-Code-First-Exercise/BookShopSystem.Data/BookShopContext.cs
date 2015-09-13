namespace BookShopSystem.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("BookShop")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }

        public virtual IDbSet<Book> Books { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("BookId");
                    m.MapRightKey("RelatedId");
                    m.ToTable("RelatedBooks");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}