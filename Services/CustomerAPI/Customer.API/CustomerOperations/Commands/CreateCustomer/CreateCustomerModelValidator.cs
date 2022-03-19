using FluentValidation;

namespace Customer.API.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerModelValidator: AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerModelValidator()
        {
            RuleFor(command => command.CreateModel.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.CreateModel.Email).NotEmpty().MinimumLength(2);
            RuleFor(command => command.CreateModel.Address.City).NotEmpty().MinimumLength(2);
            RuleFor(command => command.CreateModel.Address.Country).NotEmpty().MinimumLength(2);
            RuleFor(command => command.CreateModel.Address.CityCode).NotEmpty().GreaterThan(0);
        }
    }
}
