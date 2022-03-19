using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.API.Models.DbOperations
{
    public class CustomerDbContext : DbContext, ICustomerDbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
        { }
        public DbSet<CustomerDTO> Customers { get; set; }
        public DbSet<Address> Adresses { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is CreatedUpdated && (
            e.State == EntityState.Added
            || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((CreatedUpdated)entry.Entity).UpdatedAt = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    ((CreatedUpdated)entry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
