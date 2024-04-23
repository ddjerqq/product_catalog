using Microsoft.EntityFrameworkCore;

namespace Application.Common.Abstractions;

public interface IDbContext : IDisposable
{
    public DbSet<TEntity> Set<TEntity>()
        where TEntity : class;

    public Task<int> SaveChangesAsync(CancellationToken ct = default);
}