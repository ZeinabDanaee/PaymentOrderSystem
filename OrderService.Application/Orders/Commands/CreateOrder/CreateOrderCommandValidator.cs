using FluentValidation;

namespace OrderService.Application.Orders.Commands.CreateOrder
{
    public sealed class CreateOrderCommandValidator
     : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Items)
                .NotEmpty();

            RuleForEach(x => x.Items)
                .SetValidator(new CreateOrderItemValidator());
        }
    }
}
