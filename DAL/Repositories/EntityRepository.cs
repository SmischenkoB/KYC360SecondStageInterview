using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EntityRepository : IRepository<Entity>
    {
        private readonly LocalDbContext _dbContext;
        public EntityRepository(LocalDbContext dbContext)
        {
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            _dbContext = dbContext;
        }
        public async Task<Entity> Add(Entity entity)
        {
            var value = (await _dbContext.Entities.AddAsync(entity)).Entity;
            _dbContext.SaveChanges();
            return value;
        }

        public void Delete(string entityId)
        {
            var item = _dbContext.Entities
                .FirstOrDefault(i => i.Id == entityId);
            if (item != null)
            {
                _dbContext.Remove(item);

                if (item.Addresses.Count != 0)
                {
                    _dbContext.Addresses.RemoveRange(item.Addresses);
                }

                if (item.Names.Count != 0)
                {
                    _dbContext.Names.RemoveRange(item.Names);
                }

                if (item.Dates.Count != 0)
                {
                    _dbContext.Dates.RemoveRange(item.Dates);
                }
                _dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<Entity>> GetAll(GetRequest<Entity> request)
        {
            IQueryable<Entity> query = _dbContext.Set<Entity>();

            if (request.Filter != null)
            {
                query = query.Where(request.Filter);
            }

            if (request.OrderBy != null)
            {
                query = request.OrderBy(query);
            }

            if (request.Skip.HasValue)
            {
                query = query.Skip(request.Skip.Value);
            }

            if (request.Take.HasValue)
            {
                query = query.Take(request.Take.Value);
            }

            return query.ToList();
        }

        public async Task<Entity>? GetById(string entityId)
        {
            return _dbContext.Entities.First(i => i.Id == entityId);
        }

        public async Task<Entity> Update(Entity entity)
        {
            var item = _dbContext.Entities.Update(entity).Entity;
            _dbContext.SaveChanges();
            return item;
        }
    }
}
