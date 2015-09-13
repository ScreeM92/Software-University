namespace BugTracker.Data.UnitOfWork
{
    using BugTracker.Data.Models;
    using BugTracker.Data.Repositories;

    using Microsoft.AspNet.Identity;

    public interface IBugTrackerData
    {
        IRepository<User> Users { get; }

        IRepository<Bug> Bugs { get; }
        
        IRepository<Comment> Comments { get; }

        IUserStore<User> UserStore { get; }

        void SaveChanges();
    }
}
