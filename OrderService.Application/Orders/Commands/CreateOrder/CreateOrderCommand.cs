using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Orders.Commands.CreateOrder
{

    public record CreateOrderCommand(
        string CustomerId,
        List<CreateOrderItemDto> Items)
        : IRequest<Guid>;


    public sealed record CreateOrderItemDto(
        string ProductId,
        int Quantity,
        decimal Price
    );
}
