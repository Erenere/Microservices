using AutoMapper;
using Customer.API.Models;
using Customer.API.Models.DbOperations;
using System;
using System.Linq;

namespace Customer.API.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CustomerCreateModel CreateModel { get; set; }

        private readonly ICustomerDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(ICustomerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Guid Handle()
        {
            var customer = _mapper.Map<CustomerDTO>(CreateModel);

            if (_dbContext.Customers.SingleOrDefault(x => x.Email == customer.Email) != null)
                throw new InvalidOperationException("Email is already in use");

            _dbContext.Adresses.Add(customer.Address);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer.Id;
        }
    }

    public class CustomerCreateModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}
