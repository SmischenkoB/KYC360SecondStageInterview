using DAL;

namespace KYC360SecondStageInterview.Services
{
    public interface ICrudService<T>
    {
        public Task<IEnumerable<T>>? GetAll(GetRequest<T>? request);
        public Task<T>? Get(string id);
        public Task<T> Post(T entity);
        public Task<T>? Put(T entity);
        public void Delete(string id);
    }
}
