using FluentValidation;

namespace Customer.API.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerValidator: AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(c => c.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(c => c.Model.Email).NotEmpty().MinimumLength(2);    
        }
    }
}
