namespace OnlineShop.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using OnlineShop.Models;

    public class OnlineShopContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineShopContext()
            : base("name=OnlineShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineShopContext, Configuration>());
        }

        public virtual IDbSet<Ad> Ads { get; set; }
        public virtual IDbSet<AdType> AdTypes { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }

        public static OnlineShopContext Create()
        {
            return new OnlineShopContext();
        }
    }
}