namespace News.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<News.Data.NewsContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "News.Data.NewsContext";
        }
        
        protected override void Seed(News.Data.NewsContext context)
        {
        }
    }
}
