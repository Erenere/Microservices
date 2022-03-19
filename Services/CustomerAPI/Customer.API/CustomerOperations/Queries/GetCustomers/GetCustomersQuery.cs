using AutoMapper;
using Customer.API.Models;
using Customer.API.Models.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer.API.CustomerOperations.Queries.GetCustomers
{
    public class GetCustomersQuery
    {
        private readonly IMapper _mapper;
        private readonly ICustomerDbContext _dbContext;
        public GetCustomersQuery(ICustomerDbContext customerDbContext, IMapper mapper)
        {
            _dbContext = customerDbContext;
            _mapper = mapper;
        }

        public List<CustomersViewModel> Handle()
        {
            var customersList = _dbContext.Customers.Include(x => x.Address).OrderBy(x => x.Id).ToList<CustomerDTO>();
            List<CustomersViewModel> viewModel = _mapper.Map<List<CustomersViewModel>>(customersList);  
            return viewModel;
        }


        public class CustomersViewModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }

            public Guid AddressId { get; set; }
            public string Address { get; set; }

        }
    }
}
