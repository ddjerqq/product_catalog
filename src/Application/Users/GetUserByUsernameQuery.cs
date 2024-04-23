using Application.Common.Abstractions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users;

public record GetUserByUsernameQuery(string Username) : IRequest<User?>;

public class GetUserByUsernameQueryHandler(IDbContext db) : IRequestHandler<GetUserByUsernameQuery, User?>
{
    public async Task<User?> Handle(GetUserByUsernameQuery request, CancellationToken ct)
    {
        var user = await db.Set<User>()
            .FirstOrDefaultAsync(x => x.Username == request.Username, ct);

        return user;
    }
}
