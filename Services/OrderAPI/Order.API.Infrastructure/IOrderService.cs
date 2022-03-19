using Order.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.API.Infrastructure
{
    public interface IOrderService
    {
        public OrderDTO GetOrderById(Guid id);
    }
}
