using CarStore.Hexagonal.Application.Features.Users.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Users.Commands.AddUser
{
    internal class AddUserHandler : IRequestHandler<AddUserCommand, UserResult>
    {
        private readonly IRepository<User, string> _repo;

        public AddUserHandler(IRepository<User, string> repository)
        {
            _repo = repository;
        }

        public async Task<UserResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(new(request.FullName), new(request.Email));
            var createdUser = await _repo.AddAsync(user);
            return UserResult.FromEntity(createdUser);
        }
    }
}
