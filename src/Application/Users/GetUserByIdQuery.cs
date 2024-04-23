using Application.Common.Abstractions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users;

public record GetUserByIdQuery(Guid Id) : IRequest<User?>;

public class GetUserByIdQueryHandler(IDbContext db) : IRequestHandler<GetUserByIdQuery, User?>
{
    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        var user = await db.Set<User>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        return user;
    }
}

// public class UserController(IMediator mediator) : Controllerbase
// {
//     [httpget("users/{id}")]
//     public async Task<User> GetById(Guid id)
//     {
//         var query = new GetUserByIdQuery(id);
//         var user = await mediator.Send(query);
//
//         if (user is null) return notfound();
//         return ok(user);
//     }
// }