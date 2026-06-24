using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Orders.Commands.CreateOrder
{

    public sealed record Command(
      string CustomerId,
      List<OrderItemDto> Items
  );

    public sealed record OrderItemDto(
        string ProductId,
        int Quantity,
        decimal Price
    );
}
