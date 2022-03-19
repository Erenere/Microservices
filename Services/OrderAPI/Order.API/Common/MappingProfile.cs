using AutoMapper;
using Customer.API.CustomerOperations.Commands.CreateCustomer;
using Customer.API.Models;
using Order.API.Models;
using Order.API.OrderOperations.Commands.CreateOrder;
using Order.API.OrderOperations.Queries;
using Order.API.OrderOperations.Queries.GetOrdersOfCustomer;
using static Customer.API.CustomerOperations.Queries.GetCustomerDetail.GetCustomersDetailQuery;
using static Customer.API.CustomerOperations.Queries.GetCustomers.GetCustomersQuery;

namespace Order.API.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderViewModel, OrderDTO>();
            CreateMap<OrderDTO, OrdersViewModel>().ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address.AddressLine));
            CreateMap<OrderDTO, GetOrderDetailViewModel>().ForMember(dest => dest.Address,
                        opt => opt.MapFrom(src => src.Address.AddressLine));
            CreateMap<OrderDTO, OrdersOfCustomerViewModel>().ForMember(dest => dest.Address,
                        opt => opt.MapFrom(src => src.Address.AddressLine));

        }
    }
}
