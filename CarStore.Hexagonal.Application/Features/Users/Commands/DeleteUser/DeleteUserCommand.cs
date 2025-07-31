using MediatR;

namespace CarStore.Hexagonal.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<string>
    {
        public string UserId { get; set; }
    }
}
