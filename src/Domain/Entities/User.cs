using System.Security.Cryptography;
using System.Text;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;

    public decimal Wallet { get; set; }

    public decimal Bank { get; set; }

    public ICollection<Item> Items { get; set; } = [];

    public static User NewUser(string username, string password) => new()
    {
        Id = Guid.NewGuid(),
        Username = username,
        PasswordHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password))),
        Items = [],
    };
}