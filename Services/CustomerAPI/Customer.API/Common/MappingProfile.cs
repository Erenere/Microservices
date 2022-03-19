using AutoMapper;
using Customer.API.CustomerOperations.Commands.CreateCustomer;
using Customer.API.Models;
using static Customer.API.CustomerOperations.Queries.GetCustomerDetail.GetCustomersDetailQuery;
using static Customer.API.CustomerOperations.Queries.GetCustomers.GetCustomersQuery;

namespace Customer.API.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDTO, CustomersViewModel>().ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address.AddressLine));
            CreateMap<CustomerDTO, CustomerDetailViewModel>().ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address.AddressLine));
            CreateMap<CustomerCreateModel, CustomerDTO>();
        }
    }
}
