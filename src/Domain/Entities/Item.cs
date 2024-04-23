namespace Domain.Entities;

public class Item
{
    public static Item NewItem(string name, decimal price, User? owner) => new()
    {
        Id = Guid.NewGuid(),
        Name = name,
        Price = price,
        Rarity = Random.Shared.NextSingle(),
        Owner = owner,
     };

    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public decimal Price { get; set; }

    public float Rarity { get; set; }

    public User? Owner { get; set; }
}