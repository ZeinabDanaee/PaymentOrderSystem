using FluentValidation;

namespace OrderService.Application.Orders.Commands.CreateOrder;

public sealed class CreateOrderItemValidator
    : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.Quantity)
            .GreaterThan(0);

        RuleFor(x => x.Price)
            .GreaterThan(0);
    }
}