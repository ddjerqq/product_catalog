namespace Domain.Entities;

public class Item
{
    public static Item NewItem(string name, User? owner) => new Item
    {
        Id = Guid.NewGuid(),
        Name = name,
        Rarity = Random.Shared.NextSingle(),
        Owner = owner
     };

    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public float Rarity { get; set; }

    public User? Owner { get; set; } = default!;
}