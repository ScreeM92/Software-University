namespace OnlineShop.Data
{
    using Models;
    using Repositories;

    public interface IOnlineShopData
    {
        IRepository<Ad> Ads { get; }

        IRepository<AdType> AdTypes { get; }

        IRepository<Category> Categories { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}