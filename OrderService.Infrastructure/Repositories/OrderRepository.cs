using OrderService.Application.Orders.Abstractions;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Repositories
{
   
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public  void Add(Order order)
        {
             _context.Orders.Add(order);

            //await _context.SaveChangesAsync(
            //    cancellationToken);
        }
    }
}
