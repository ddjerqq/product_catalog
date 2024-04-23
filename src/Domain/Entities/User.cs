﻿namespace Domain.Entities;

public class User
{
    public static User NewUser(string username) => new()
    {
        Id = Guid.NewGuid(),
        Username = username,
        Items = [],
    };

    public Guid Id { get; set; }

    public string Username { get; set; } = default!;

    public ICollection<Item> Items { get; set; } = [];
}