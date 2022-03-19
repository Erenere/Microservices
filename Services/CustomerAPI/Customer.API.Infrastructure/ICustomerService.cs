using Customer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.API.Infrastructure
{
    public interface ICustomerService 
    {
        public CustomerDTO GetCustomerById(Guid Id);
    }
}
