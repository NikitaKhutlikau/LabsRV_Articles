using LabsRV_Articles.Models.Domain;


namespace LabsRV_Articles.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : IEntity
    {
        protected readonly Dictionary<int, T> _store = new Dictionary<int, T>();
        protected int _nextId = 1;

        public virtual T Add(T entity)
        {
            entity.Id = _nextId++;
            _store[entity.Id] = entity;
            return entity;
        }

        public virtual T GetById(int id)
        {
            _store.TryGetValue(id, out T entity);
            return entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _store.Values;
        }

        public virtual T Update(T entity)
        {
            if (!_store.ContainsKey(entity.Id))
                throw new KeyNotFoundException($"{typeof(T).Name} with id {entity.Id} not found");
            _store[entity.Id] = entity;
            return entity;
        }

        public virtual bool Delete(int id)
        {
            return _store.Remove(id);
        }
    }
}
