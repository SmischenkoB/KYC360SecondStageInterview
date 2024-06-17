

namespace DAL.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        void Delete(string entityId);
        Task<IEnumerable<T>> GetAll(GetRequest<T> request);
        Task<T>? GetById(string entityId);
    }
}
