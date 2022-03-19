using Customer.API.CustomerOperations.Commands.CreateCustomer;
using FluentValidation;

namespace Customer.API.Controllers
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(command => command.CreateModel.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.CreateModel.Email).NotEmpty().MinimumLength(2);
            RuleFor(command => command.CreateModel.Address.City).NotEmpty().MinimumLength(2);
            RuleFor(command => command.CreateModel.Address.Country).NotEmpty().MinimumLength(2);
            RuleFor(command => command.CreateModel.Address.CityCode).NotEmpty().GreaterThan(0);
        }
    }
}