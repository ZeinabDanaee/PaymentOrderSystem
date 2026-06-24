using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Orders.Abstractions
{
    public interface IOrderRepository
    {
        Task Add(Order order, CancellationToken cancellationToken);
    }
}
