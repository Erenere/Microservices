using Customer.API.Models;
using Customer.API.Models.DbOperations;
using System;
using System.Linq;

namespace Customer.API.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        private readonly ICustomerDbContext _context;

        public Guid CustomerId { get; set; }
        public UpdateCustomerModel Model;

        public UpdateCustomerCommand(ICustomerDbContext customerDbContext)
        {
            _context = customerDbContext;
        }

        public bool Handle()
        {
            var customer = _context.Customers.SingleOrDefault(book => book.Id == CustomerId);
            if (customer == null)
                throw new InvalidOperationException("Customer could not be found");

            var updatedAddress = new Address
            {
                City = Model.Address.City,
                Country = Model.Address.Country,
                CityCode = Model.Address.CityCode,
            };

            customer.Address = updatedAddress!= default ? updatedAddress : customer.Address;
            customer.Name = Model.Name != default ? Model.Name : customer.Name; 
            customer.Email = Model.Email != default ? Model.Email : customer.Email;

            _context.SaveChanges();
            return true;
        }

    }

    public class UpdateCustomerModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}
