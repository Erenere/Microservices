using FluentValidation;

namespace Order.API.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            //RuleFor(command => command.Model.CustomerId).NotEmpty();
            RuleFor(command => command.ViewModel.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(command => command.ViewModel.Price).NotEmpty().GreaterThan(0);
            RuleFor(command => command.ViewModel.Address).NotEmpty();
            RuleFor(command => command.ViewModel.ProductId).NotEmpty();
            RuleFor(command => command.ViewModel.Status).NotEmpty();
        }
    }
}
