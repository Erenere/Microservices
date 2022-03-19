using Order.API.Models.DbOperations;
using System;
using System.Linq;

namespace Order.API.OrderOperations.Commands.ChangeStatus
{
    public class ChangeStatusCommand
    {
        private readonly IOrderDbContext _orderDbContext;

        public Guid OrderId { get; set; }
        public ChangeStatusViewModel Model { get; set; }

        public ChangeStatusCommand(IOrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public bool Handle()
        {
            var order = _orderDbContext.GetOrders.SingleOrDefault(book=>book.Id == OrderId);
            if (order == null)
                throw new InvalidOperationException("Order could not be found");

            order.Status = Model.Status!= default? Model.Status: order.Status;
            _orderDbContext.SaveChanges();
            return true;
        }

    }

    public class ChangeStatusViewModel
    {
        public string Status { get; set; }
    }
}
