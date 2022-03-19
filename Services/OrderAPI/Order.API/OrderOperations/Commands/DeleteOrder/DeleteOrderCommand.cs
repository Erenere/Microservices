using Order.API.Models.DbOperations;
using System;
using System.Linq;

namespace Order.API.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
        private readonly IOrderDbContext _orderDbContext;

        public DeleteOrderCommand(IOrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public Guid OrderId { get; set; }
        
        public bool Handle()
        {
            var customer = _orderDbContext.GetOrders.SingleOrDefault(customer => customer.Id == OrderId);
            if (customer == null)
                throw new InvalidOperationException("Customer does not exist");

            _orderDbContext.GetOrders.Remove(customer);
            _orderDbContext.SaveChanges();
            return true;
        }
    }
}
