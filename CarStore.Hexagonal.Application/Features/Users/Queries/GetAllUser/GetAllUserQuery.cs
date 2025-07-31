using CarStore.Hexagonal.Application.Features.Users.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Users.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserResult>> { }
}
