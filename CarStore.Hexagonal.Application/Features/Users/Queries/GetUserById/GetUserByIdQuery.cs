using CarStore.Hexagonal.Application.Features.Users.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserResult>
    {
        public string UserId { get; set; }
    }
}
