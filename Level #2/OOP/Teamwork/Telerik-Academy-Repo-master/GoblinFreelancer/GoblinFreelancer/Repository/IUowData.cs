namespace GoblinFreelancer.Repository
{
    using GoblinFreelancer.Models;
    using System;

    public interface IUowData : IDisposable
    {
        IRepository<Message> Messages { get; }
        IRepository<Project> Projects { get; }
        IRepository<Skill> Skills { get; }
        IRepository<Category> Categories { get; }
        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
