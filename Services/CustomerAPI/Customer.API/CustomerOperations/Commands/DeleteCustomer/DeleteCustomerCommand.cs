using Customer.API.Models.DbOperations;
using System;
using System.Linq;

namespace Customer.API.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        private readonly ICustomerDbContext _context;

        public DeleteCustomerCommand(ICustomerDbContext context)
        {
            _context = context;
        }

        public Guid CustomerId { get; set; }
        public bool Handle()
        {
            var customer = _context.Customers.SingleOrDefault(customer => customer.Id == CustomerId);
            if (customer == null)
                throw new InvalidOperationException("Customer does not exist");

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }
    }
}
