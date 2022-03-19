using Customer.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.API.Models.DbOperations
{
    public interface IOrderDbContext
    {
        DbSet<OrderDTO> GetOrders { get; set; }
        DbSet<Address> GetAddresses { get; set; }  
        DbSet<Product> GetProducts { get; set; }    
        int SaveChanges();
    }
}
