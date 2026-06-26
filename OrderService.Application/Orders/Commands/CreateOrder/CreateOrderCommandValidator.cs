using FluentValidation;

namespace OrderService.Application.Orders.Commands.CreateOrder
{
    public sealed class CreateOrderCommandValidator
     : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty();

            RuleFor(x => x.Items)
                .NotEmpty();
        }
    }
}
