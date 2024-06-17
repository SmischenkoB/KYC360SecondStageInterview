using DAL;
using DAL.Entities;
using DAL.Repositories;

namespace KYC360SecondStageInterview.Services
{
    public class EntityService : ICrudService<Entity>
    {
        private readonly IRepository<Entity> _entityRepository;

        public EntityService(IRepository<Entity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public void Delete(string id)
        {
            _entityRepository.Delete(id);
        }

        public Task<Entity>? Get(string id)
        {
            return _entityRepository.GetById(id);
        }

        public Task<IEnumerable<Entity>>? GetAll(GetRequest<Entity>? request)
        {
            return _entityRepository.GetAll(request);
        }

        public Task<Entity> Post(Entity entity)
        {
            return _entityRepository.Add(entity);
        }

        public Task<Entity>? Put(Entity entity)
        {
            return _entityRepository.Update(entity);
        }
    }
}
