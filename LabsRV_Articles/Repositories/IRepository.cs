using LabsRV_Articles.Models.Domain;

namespace LabsRV_Articles.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        T Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Update(T entity);
        bool Delete(int id);
    }
}

