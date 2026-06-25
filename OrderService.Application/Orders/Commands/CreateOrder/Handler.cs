using MediatR;
using OrderService.Application.Orders.Abstractions;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Orders.Commands.CreateOrder
{
    public class Handler
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(
    Command request,
    CancellationToken cancellationToken)
        {
            var order = new Order(request.CustomerId);

            foreach (var item in request.Items)
            {
                order.AddItem(
                    item.ProductId,
                    item.Quantity,
                    item.Price);
            }

            _orderRepository.Add(order);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}