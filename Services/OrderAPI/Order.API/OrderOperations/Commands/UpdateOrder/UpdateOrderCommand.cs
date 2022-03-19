using Customer.API.Models;
using Order.API.Models;
using Order.API.Models.DbOperations;
using System;
using System.Linq;

namespace Order.API.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        private readonly IOrderDbContext _orderDbContext;
        public Guid orderId { get; set; }

        public UpdatedOrderModel updatedOrderModel { get; set; }
        public UpdateOrderCommand (IOrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public bool Handle()
        {
            var order = _orderDbContext.GetOrders.SingleOrDefault(b => b.Id == orderId);
            if (order is null)
                throw new InvalidOperationException("Order could not be found");

            var updatedAddress = new Address
            {
                City = updatedOrderModel.Address.City,
                Country = updatedOrderModel.Address.Country,
                CityCode = updatedOrderModel.Address.CityCode,
            };
            var updatedProduct = new Product
            {
                ImageUrl = updatedOrderModel.Product.ImageUrl,
                Name = updatedOrderModel.Product.Name,
            };

            order.Address = updatedAddress != default ? updatedAddress : order.Address;
            order.Product = updatedOrderModel.Product != default ? updatedProduct : order.Product;
            order.Quantity = updatedOrderModel.Quantity != default ? updatedOrderModel.Quantity : order.Quantity;
            order.Price = updatedOrderModel.Price != default ? updatedOrderModel.Price : order.Price;
            order.Status = updatedOrderModel.Status != default ? updatedOrderModel.Status : order.Status;

            _orderDbContext.SaveChanges();
            return true;
        }

    }

    public class UpdatedOrderModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
        public Address Address { get; set; }
    }
}
