using System.Linq;

namespace NewsDb.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "NewsDB.SqlMarketContext";
        }

        protected override void Seed(NewsContext context)
        {
            if (!context.News.Any())
            {
                context.News.AddOrUpdate(n => n.Id,
                new News { Content = "EF 7 Beta To Be Released in May 2016." },
                new News { Content = "DbMigrationsConfiguration(TContext).Seed Method" },
                new News { Content = "Latest Technology News - C# Corner" },
                new News { Content = "The Past, Present, and Future of C#" });
            }
        }
    }
}
