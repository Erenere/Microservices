using AutoMapper;
using Customer.API.Models;
using Order.API.Models;
using Order.API.Models.DbOperations;
using System;

namespace Order.API.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderViewModel ViewModel { get; set; }

        private readonly IOrderDbContext _orderDbContext;
        private readonly IMapper _mapper;

        public CreateOrderCommand( IOrderDbContext orderDbContext, IMapper mapper)
        {
            _orderDbContext = orderDbContext;
            _mapper = mapper;
        }

        public Guid Handle()
        {
            var order = _mapper.Map<OrderDTO>(ViewModel);
            _orderDbContext.GetAddresses.Add(order.Address);

            _orderDbContext.GetOrders.Add(order);
            _orderDbContext.SaveChanges();
            return order.Id;

        }

    }

    public class CreateOrderViewModel
    {
        public Guid CustomerId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public Address Address { get; set; }
        public Guid ProductId { get; set; }
    }
}
