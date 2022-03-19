using Customer.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.API.Models.DbOperations
{
    public class OrderDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new OrderDbContext(serviceProvider.GetRequiredService<DbContextOptions<OrderDbContext>>()))
	        {
                if (context.GetOrders.Any())
                {
                    return;
                }
                context.GetAddresses.AddRange(
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
                context.GetProducts.AddRange(
                    new Product
                    {
                        Id= new Guid("5022a8fc-6485-407d-9b9f-4815b8a9dc97"),
                        Name = "Product1",
                        ImageUrl ="imageurl1.com"
                    },
                    new Product
                    {
                        Id = new Guid("c4370c81-d312-4006-a3c8-ccc4445fad38"),
                        Name = "product2",
                        ImageUrl = "imageurl2.com"
                    },
                    new Product
                    {
                        Id = new Guid("f0cc23c8-5daf-4406-a26a-98f406de4487"),
                        Name = "product3",
                        ImageUrl =  "imageurl3.com"
                    }                   
                    );
                context.SaveChanges();
	        }
        }
        
    }
}
