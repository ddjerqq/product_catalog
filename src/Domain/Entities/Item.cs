namespace Domain.Entities;

public class Item
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public float Rarity { get; set; }

    public User Owner { get; set; } = default!;
}