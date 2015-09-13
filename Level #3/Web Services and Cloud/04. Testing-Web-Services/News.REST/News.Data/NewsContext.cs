namespace News.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class NewsContext : IdentityDbContext<ApplicationUser>
    {
        public NewsContext()
            : base("name=NewsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsContext, Configuration>());
        }

        public static NewsContext Create()
        {
            return new NewsContext();
        }

        public virtual IDbSet<News> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .HasRequired<ApplicationUser>(p => p.Author)
                .WithMany(a => a.News)
                .WillCascadeOnDelete(false);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}