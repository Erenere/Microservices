using AutoMapper;
using Customer.API.Common;
using Customer.API.Models.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSetup;

namespace Customer.Tests.TestSetup
{
    public class CommonTestFixture
    {
        public CustomerDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>().UseInMemoryDatabase("CustomerTestDb").Options;
            Context = new CustomerDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddCustomers();
            Context.AddAddresses();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg =>
            { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}
