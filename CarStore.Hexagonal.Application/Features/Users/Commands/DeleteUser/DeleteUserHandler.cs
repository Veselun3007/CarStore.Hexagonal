using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Users.Commands.DeleteUser
{
    internal class DeleteUserHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IRepository<User, string> _repo;

        public DeleteUserHandler(IRepository<User, string> repository)
        {
            _repo = repository;
        }

        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.UserId);
            return "User success deleted";
        }
    }
}
