namespace GoblinFreelancer.Repository
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);

        DbEntityEntry Entry(T entity);
    }
}
