using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.API.Models;
using Order.API.Models.DbOperations;
using System;
using System.Linq;

namespace Order.API.OrderOperations.Queries
{
    public class GetOrderDetailQuery
    {
        private readonly IMapper _mapper;
        private readonly IOrderDbContext _orderDbContext;

        public GetOrderDetailQuery(IMapper mapper, IOrderDbContext orderDbContext)
        {
            _mapper = mapper;
            _orderDbContext = orderDbContext;
        }

        public Guid orderId { get; set; }

        public GetOrderDetailViewModel Handle()
        {
            var order = _orderDbContext.GetOrders.Include(a => a.Address).Include(a => a.Product).SingleOrDefault(order => order.Id == orderId);
            if (order is null)
                throw new InvalidOperationException("Customer cannot be found");

            GetOrderDetailViewModel viewModel = _mapper.Map<GetOrderDetailViewModel>(order);
            return viewModel;
        }

    }

    public class GetOrderDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Address { get; set; }
        public Product Product { get; set; }
    }
}
