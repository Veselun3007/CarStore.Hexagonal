using CarStore.Hexagonal.Application.Features.Users.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserResult>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
