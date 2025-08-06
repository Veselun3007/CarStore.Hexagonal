using CarStore.Hexagonal.Application.Features.Users.Common;
using CarStore.Hexagonal.Application.Features.Users.Queries.GetAllUser;
using CarStore.Hexagonal.Application.Features.Users.Queries.GetUserById;
using MediatR;

namespace CarStore.Hexagonal.Presentation.GraphQl.Queries
{
    public class UserQueries
    {
        public async Task<IEnumerable<UserResult>?> GetUsersAsync([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetAllUserQuery(), cancellationToken);
        }

        public async Task<UserResult?> GetUserById([Service] IMediator mediator, string userId, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetUserByIdQuery { UserId = userId }, cancellationToken);
        }
    }
}
