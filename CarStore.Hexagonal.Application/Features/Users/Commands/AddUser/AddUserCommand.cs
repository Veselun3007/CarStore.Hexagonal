using CarStore.Hexagonal.Application.Features.Users.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<UserResult>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
