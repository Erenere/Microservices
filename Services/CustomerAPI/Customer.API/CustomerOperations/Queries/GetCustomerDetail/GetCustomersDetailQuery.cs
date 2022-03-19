using AutoMapper;
using Customer.API.Models.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Customer.API.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomersDetailQuery
    {
        private readonly ICustomerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomersDetailQuery(ICustomerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Guid CustomerId { get; set; }

        public CustomerDetailViewModel Handle()
        {
            var customer = _dbContext.Customers.Include(x => x.Address).SingleOrDefault(customer => customer.Id == CustomerId);

            if (customer is null)
                throw new InvalidOperationException("Customer cannot be found");

            CustomerDetailViewModel viewModel = new CustomerDetailViewModel(); 
            return viewModel;
        }

        public class CustomerDetailViewModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }

            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

    }
}
