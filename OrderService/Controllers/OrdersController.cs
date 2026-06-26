using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Orders.Commands.CreateOrder;

namespace OrderService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;

    public OrdersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
    CreateOrderCommand command,
    CancellationToken cancellationToken)
    {
        var orderId = await _sender.Send(
            command,
            cancellationToken);

        return Ok(orderId);
    }
}