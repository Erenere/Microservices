using Customer.API.Models;
using Customer.API.Models.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.API.Models.DbOperations
{
    public class OrderDbContext : DbContext, IOrderDbContext
    { 
        public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options)
        { }
        public DbSet<Product> GetProducts { get; set;}
        public DbSet<OrderDTO> GetOrders { get; set;}
        public DbSet<Address> GetAddresses { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e=>e.Entity is CreatedUpdated && 
                (e.State==EntityState.Added || e.State==EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((CreatedUpdated)entityEntry.Entity).UpdatedAt = DateTime.Now;
                if (entityEntry.State == EntityState.Added)
                {
                    ((CreatedUpdated)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
    

}
