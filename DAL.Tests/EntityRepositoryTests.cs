using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tests
{
    public class EntityRepositoryTests
    {
        [Fact]
        public async Task AddEntitySuccessful()
        {
            //await using var connection = new SqlConnection(_msSqlContainer.GetConnectionString());
            var entityRepository = new EntityRepository(new LocalDbContext("testRoute.db"));
            var testItem = new Entity()
            {
                Id = "first",
                Deceased = false,
                Gender = "male",
                

                Addresses = new List<Address>()
                {
                   //new Address()
                   //{ 
                   //     AddressLine = "address line 2",
                   //     City = "Some City",
                   //     Country = "SomeCountry",
                   //     //Id = 75
                   //}
                },

                Dates = new List<Date>()
                {
                    //new Date()
                    //{ 
                    //    //Id  = 14,
                    //    DateTime = DateTime.Now,
                    //    DateType = "GMT0"
                    //}
                },

                Names = new List<Name>()
                { 
                    //new Name()
                    //{ 
                    //    //Id = 7,
                    //    FirstName = "f",
                    //    MiddleName = "g",
                    //    Surname = "h"
                    //}
                }
            };

            var res = await entityRepository.Add(testItem);
            
            Assert.Equal(testItem.Id, res.Id);
            Assert.Single(await entityRepository.GetAll(new GetRequest<Entity>()));

            entityRepository.Delete(testItem.Id);
        }
    }
}
