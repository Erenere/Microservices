using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.API.Models;
using Order.API.Models.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.API.OrderOperations.Queries.GetOrdersOfCustomer
{
    public class GetOrdersOfCustomerQuery
    {
        private readonly IOrderDbContext _orderDbContext;
        private readonly IMapper _mapper;

        public Guid customerId;

        public GetOrdersOfCustomerQuery(IOrderDbContext orderDbContext, IMapper mapper)
        {
            _orderDbContext = orderDbContext;
            _mapper = mapper;
        }

        public List<OrdersOfCustomerViewModel> Handle()
        {
            var orderList = _orderDbContext.GetOrders.Include(a=>a.Address).Include(a=>a.Product).Where(order=>order.CustomerId==customerId).OrderBy(a=>a.Id).ToList<OrderDTO>();
            List<OrdersOfCustomerViewModel> viewModel = _mapper.Map<List<OrdersOfCustomerViewModel>>(orderList);
            return viewModel;
        }

    }

    public class OrdersOfCustomerViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid AddressId { get; set; }
        public string Address { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

    }
}
