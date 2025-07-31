using CarStore.Hexagonal.Application.Features.Users.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Users.Commands.UpdateUser
{
    internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserResult>
    {
        private readonly IRepository<User, string> _repo;

        public UpdateUserHandler(IRepository<User, string> repository)
        {
            _repo = repository;
        }

        public async Task<UserResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Id, new(request.FullName), new(request.Email));
            var updatedUser = await _repo.UpdateAsync(request.Id, user);
            return UserResult.FromEntity(updatedUser);
        }
    }
}
