namespace OrderService.Domain.Entities;

public class Order
{
    public Order(string customerId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        CreatedAt = DateTime.UtcNow;
        Status = OrderStatus.Pending;
    }

    private Order()
    {
        
    }
    public Guid Id { get; set; }

    public string CustomerId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public OrderStatus Status { get; set; }

    public decimal TotalAmount { get; set; }

    public List<OrderItem> Items { get; set; } = new();

    public void AddItem(string productId, int qty, decimal price)
    {
        if (qty <= 0)
            throw new Exception("Quantity must be greater than zero");

        Items.Add(new OrderItem
        {
            Id = Guid.NewGuid(),
            ProductId = productId,
            Quantity = qty,
            Price = price
        });

        RecalculateTotal();
    }
    private void RecalculateTotal()
    {
        TotalAmount = Items.Sum(x => x.Price * x.Quantity);
    }

}
