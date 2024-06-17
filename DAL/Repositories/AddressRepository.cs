using Azure.Core;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly LocalDbContext _dbContext;

        public AddressRepository(LocalDbContext dbContext)
        {
            //dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            _dbContext = dbContext;
        }
        public async Task<Address> Add(Address entity)
        {
            var value = (await _dbContext.Addresses.AddAsync(entity)).Entity;
            _dbContext.SaveChanges();
            return value;
        }

        public void Delete(string entityId)
        {
            var item = _dbContext.Addresses
                .FirstOrDefault(i => i.AddressLine == entityId);
            if (item != null)
            {
                _dbContext.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<Address>> GetAll(GetRequest<Address> request)
        {
            IQueryable<Address> query = _dbContext.Set<Address>();

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

        public async Task<Address>? GetById(string entityId)
        {
            return _dbContext.Addresses.First(i => i.AddressLine == entityId);
        }

        public async Task<Address> Update(Address entity)
        {
            var item = _dbContext.Addresses.Update(entity).Entity;
            _dbContext.SaveChanges();
            return item;
        }
    }
}
