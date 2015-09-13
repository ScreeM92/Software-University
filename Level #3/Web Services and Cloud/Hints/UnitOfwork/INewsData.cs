namespace News.Data.Contracts
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public interface INewsData
    {
        IRepository<News> News { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<IdentityRole> UserRoles { get; }
        
        int SaveChanges();
    }
}