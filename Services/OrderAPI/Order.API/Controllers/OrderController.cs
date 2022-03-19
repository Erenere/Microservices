using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.Clients;
using Order.API.Models.DbOperations;
using Order.API.OrderOperations.Commands.ChangeStatus;
using Order.API.OrderOperations.Commands.CreateOrder;
using Order.API.OrderOperations.Commands.DeleteOrder;
using Order.API.OrderOperations.Commands.UpdateOrder;
using Order.API.OrderOperations.Queries;
using Order.API.OrderOperations.Queries.GetOrdersOfCustomer;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //    private readonly IOrderDbContext _orderDbContext;
        //    private readonly IMapper _mapper;
        //    private readonly CustomerClient _customerClient;
        //    public OrderController(IOrderDbContext orderDbContext, IMapper mapper, CustomerClient customerClient)
        //    {
        //        _orderDbContext = orderDbContext;
        //        _mapper = mapper;
        //        _customerClient  = customerClient ;
        //    }

        //    [HttpGet("{id}")]
        //    public IActionResult GetById(Guid id)
        //    {
        //        GetOrderDetailViewModel res;
        //        GetOrderDetailQuery orderDetailQuery = new GetOrderDetailQuery(_mapper,_orderDbContext);

        //        orderDetailQuery.orderId = id;
        //        res = orderDetailQuery.Handle();
        //        return Ok(res);
        //    }

        //    [HttpGet]
        //    public IActionResult Get()
        //    {
        //        GetOrderQuery orderQuery = new GetOrderQuery(_orderDbContext, _mapper);
        //        var result = orderQuery.Handle();
        //        return Ok(result);
        //    }

        //    [HttpGet("customers/{id}")]
        //    public IActionResult GetOrdersByCustomerId(Guid id)
        //    {
        //        GetOrdersOfCustomerQuery customerQuery = new GetOrdersOfCustomerQuery(_orderDbContext, _mapper);
        //        customerQuery.customerId = id;
        //        var res = customerQuery.Handle();
        //        return Ok(res);
        //    }


        //    [HttpPost]
        //    public async Task<IActionResult> AddOrder([FromBody] CreateOrderViewModel newOrder)
        //    {
        //        CreateOrderCommand orderCommand = new CreateOrderCommand(_orderDbContext, _mapper);
        //        orderCommand.ViewModel = newOrder;

        //        var customerList = await _customerClient.GetCustomersAsync();
        //        var customer = customerList.SingleOrDefault(x => x.Id == orderCommand.ViewModel.CustomerId);
        //        if (customer == null)
        //            throw new InvalidOperationException("Customer could not be found");

        //        orderCommand.ViewModel.Address.Id = Guid.NewGuid();

        //        var product = _orderDbContext.GetProducts.SingleOrDefault(x => x.Id== orderCommand.ViewModel.ProductId);
        //        if (product == null)
        //            throw new InvalidOperationException("Product could not be found");

        //        orderCommand.ViewModel.ProductId = product.Id;

        //        CreateOrderValidator validator = new CreateOrderValidator();
        //        validator.ValidateAndThrow(orderCommand);
        //        Guid newOrderId = orderCommand.Handle();
        //        return Ok(newOrderId);

        //    }

        //    [HttpPut("{id}")]
        //    public IActionResult OrderUpdate(Guid id, [FromBody] UpdatedOrderModel orderModel)
        //    {
        //        UpdateOrderCommand command = new UpdateOrderCommand(_orderDbContext);
        //        command.orderId = id;
        //        command.updatedOrderModel = orderModel;

        //        bool isUpdated = command.Handle();
        //        return Ok(isUpdated);
        //    }

        //    [HttpPatch("{id}")]
        //    public IActionResult ChangeStatus(Guid id, [FromBody] ChangeStatusViewModel viewModel)
        //    {
        //        ChangeStatusCommand command = new ChangeStatusCommand(_orderDbContext); 
        //        command.OrderId = id;   
        //        command.Model = viewModel;

        //        bool isUpdated = command.Handle();
        //        return Ok(isUpdated);
        //    }

        //    [HttpDelete("{id}")]
        //    public IActionResult DeleteOrder(Guid id)
        //    {
        //        DeleteOrderCommand command = new DeleteOrderCommand(_orderDbContext);
        //        command.OrderId=id;
        //        bool isDeleted = command.Handle();
        //        return Ok(command);
        //    }

        //
            private readonly IOrderDbContext _context;
            private readonly IMapper _mapper;
            private readonly CustomerClient _customerClient;

            public OrderController(IOrderDbContext context, IMapper mapper, CustomerClient customerClient)
            {
                _context = context;
                _mapper = mapper;
                _customerClient = customerClient;
            }

            [HttpGet]
            public IActionResult GetOrders()
            {
                GetOrderQuery query = new GetOrderQuery(_context, _mapper);
                var result = query.Handle();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(Guid id)
            {
                GetOrderDetailViewModel result;

                GetOrderDetailQuery query = new GetOrderDetailQuery(_mapper,  _context);
                query.orderId = id;
                //GetCustomerDetailQueryValidator validator = new GetCustomerDetailQueryValidator();
                //validator.ValidateAndThrow(query);
                result = query.Handle();
                return Ok(result);
            }

            [HttpGet("Customers/{id}")]
            public IActionResult GetOrdersByCustomerId(Guid id)
            {

                GetOrdersOfCustomerQuery query = new GetOrdersOfCustomerQuery(_context, _mapper);
                query.customerId = id;
                var result = query.Handle();
                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> AddOrder([FromBody] CreateOrderViewModel newOrder)
            {
                //CreateAddress command2 = new CreateAddress(_context, _mapper);
                //command2.Model = newCustomer.Address;
                //command2.Handle();

                CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
                command.ViewModel = newOrder;

                var customerList = await _customerClient.GetCustomersAsync();
                var customer = customerList.SingleOrDefault(x => x.Id == command.ViewModel.CustomerId);
                if (customer == null)
                    throw new InvalidOperationException("Customer could not be found");

                command.ViewModel.Address.Id = Guid.NewGuid();
                //command.Model.CustomerId = id;

                var product = _context.GetProducts.SingleOrDefault(p => p.Id == command.ViewModel.ProductId);
                if (product == null)
                    throw new InvalidOperationException("Product could not be found");

                command.ViewModel.ProductId = product.Id;

                CreateOrderValidator validator = new CreateOrderValidator();
                validator.ValidateAndThrow(command);
                Guid newOrderId = command.Handle();
                return Ok(newOrderId);
            }



            [HttpPut("{id}")]
            public IActionResult UpdateOrder(Guid id, [FromBody] UpdatedOrderModel updatedOrder)
            {
                UpdateOrderCommand command = new UpdateOrderCommand(_context);
                command.orderId = id;
                command.updatedOrderModel = updatedOrder;
                //UpdateCustomerValidator validator = new UpdateCustomerValidator();
                //validator.ValidateAndThrow(command);
                bool isUpdated = command.Handle();
                return Ok(isUpdated);
            }

            [HttpPatch("{id}")]
            public IActionResult ChangeStatus(Guid id, [FromBody] ChangeStatusViewModel model)
            {
                ChangeStatusCommand command = new ChangeStatusCommand(_context);
                command.OrderId = id;
                command.Model = model;
                bool isUpdated = command.Handle();
                return Ok(isUpdated);
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteOrder(Guid id)
            {
                DeleteOrderCommand command = new DeleteOrderCommand(_context);
                command.OrderId = id;
                bool isUpdated = command.Handle();
                return Ok(isUpdated);
            }
        }
  
}
