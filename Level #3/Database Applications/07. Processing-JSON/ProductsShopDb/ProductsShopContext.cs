namespace ProductsShop.Data
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Migrations;
    using ProducstShop.Models;

    public class ProductsShopContext : DbContext
    {
        public ProductsShopContext()
            : base("name=ProductsShop")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductsShopContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendsId");
                    m.ToTable("UserFriends");
                });

            modelBuilder.Entity<User>().HasMany(u => u.ProductsSold).WithRequired(p => p.Seller);
            modelBuilder.Entity<User>().HasMany(u => u.ProductsBought).WithOptional(p => p.Buyer);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[] 
                { 
                    new IndexAttribute("Index") { IsUnique = true } 
                }));

            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Product> Products { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
    }
}