using DAL.Entities;
using DAL.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MsSql;

namespace DAL.Tests
{
    public class AddressRepositoryTests 
    {
        //private readonly MsSqlContainer _msSqlContainer
        //= new MsSqlBuilder().Build();
        
        [Fact]
        public async Task AddAddressSuccessful()
        {
            //await using var connection = new SqlConnection(_msSqlContainer.GetConnectionString());
            var addressRepository = new AddressRepository(new LocalDbContext("testRoute.db"));

            var testItem = new Address()
                { AddressLine = "address line 1", City = "Some City",
                Country = "SomeCountry" };
            
            var res = await addressRepository.Add(testItem);
            
            Assert.Equal(testItem.AddressLine, res.AddressLine);
            Assert.Single(await addressRepository.GetAll(new GetRequest<Address>()));

            addressRepository.Delete(testItem.AddressLine);
        }

    }
}
