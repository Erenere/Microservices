using FluentValidation;

namespace Customer.API.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryValidator : AbstractValidator<GetCustomersDetailQuery>
    {
        public GetCustomerDetailQueryValidator()
        {
            RuleFor(command => command.CustomerId).NotEmpty();
        }
    }
   
}
