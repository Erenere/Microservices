using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.API.Models.DbOperations
{
    public class CustomerDataGenerator
    {
        public static void Initializer (IServiceProvider ServiceProvider)
        {
            using (var context = new CustomerDbContext(ServiceProvider.GetRequiredService<DbContextOptions<CustomerDbContext>>()))
            {
                if (context.Customers.Any())
                {
                    return;
                }

                context.Adresses.AddRange(
                    new Address
                    {
                        Id = new Guid("d225ce79-192c-4a63-81b0-bb49781a6c91"),
                        Country = "Turkey",
                        City = "Istanbul",
                        CityCode = 3434
                    },
                    new Address
                    {
                        Id = new Guid("fda1d9de-6a55-4bb8-a65c-86148f9e0d6e"),
                        Country = "Italy",
                        City = "Rome",
                        CityCode = 1616
                    }
                    );

                context.Customers.AddRange(
                    new CustomerDTO
                    {
                        Name = "Fname Lname",
                        //Id = new Guid("12aa5e88-0381-4a82-bba1-30a4fffb87e2"),
                        //Address = new Address { Id = new Guid("fda1d9de-6a55-4bb8-a65c-86148f9e0d6e") },
                        Email = "sample@mail.com",
                        AddressId = new Guid("d225ce79-192c-4a63-81b0-bb49781a6c91"),
                        CreatedAt = DateTime.Now,   
                        UpdatedAt = DateTime.Now,
                    },
                    new CustomerDTO
                    {
                        Name = "Fname2 Lname2",
                        //Id = new Guid("51ff9f94-d721-48bd-a5ed-5d41048db11a"),
                        //Address = new Address { Id = new Guid("d225ce79-192c-4a63-81b0-bb49781a6c91") },
                        Email= "sample2@mail2.com",
                        AddressId = new Guid("fda1d9de-6a55-4bb8-a65c-86148f9e0d6e"),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
