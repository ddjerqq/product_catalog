using Application.Common.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IDbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Item> Item => Set<Item>();
}