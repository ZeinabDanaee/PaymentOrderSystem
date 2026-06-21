namespace OrderService.Domain.Entities;

public enum OrderStatus
{
    Pending = 0,
    Paid = 1,
    Failed = 2,
    Cancelled = 3
}