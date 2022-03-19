using Customer.API.Infrastructure;
using Customer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.API.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerDTO GetCustomerById(Guid Id)
        {
            return new CustomerDTO()
            {
                Id = Id,
                Name = "Name",
                Address = new Address
                {
                    Id = Guid.NewGuid(),
                    City = "City",
                    Country ="Country",
                    CityCode = 1111,
                }
            };
        }
    }
}
