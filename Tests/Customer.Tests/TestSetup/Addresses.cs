using Customer.API.Models.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Tests.TestSetup
{
    public static class Addresses
    {
        public static void AddAddresses(this CustomerDbContext context)
        {
            context.Adresses.AddRange(
                
                );
        }
    }
}
