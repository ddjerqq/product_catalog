namespace Domain.Entities;

public class Order
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public Product Product { get; set; } = default!;
}