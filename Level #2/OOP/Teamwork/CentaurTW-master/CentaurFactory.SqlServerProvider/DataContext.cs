namespace CentaurFactory.SqlServerProvider
{
    using System.Data.Entity;

    using CentaurFactory.Model;
    using CentaurFactory.SqlServerProvider.Mapping;
    using CentaurFactory.SqlServerProvider.Migrations;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("SQLServer")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Config>());
        }

        public DataContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<UnitType> UnitTypes { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductTypeMap());
            modelBuilder.Configurations.Add(new UnitTypeMap());
            modelBuilder.Configurations.Add(new DishMap());
            modelBuilder.Configurations.Add(new IngredientMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
