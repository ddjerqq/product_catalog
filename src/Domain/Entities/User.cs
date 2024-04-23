namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = default!;

    public ICollection<Item> Items { get; set; } = [];
}