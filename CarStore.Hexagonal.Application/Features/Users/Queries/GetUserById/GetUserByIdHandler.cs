using CarStore.Hexagonal.Application.Features.Users.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Users.Queries.GetUserById
{
    internal class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResult?>
    {
        private readonly IRepository<User, string> _repo;

        public GetUserByIdHandler(IRepository<User, string> repository)
        {
            _repo = repository;
        }

        public async Task<UserResult?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.FindByIdAsync(request.UserId);
            return UserResult.FromEntity(user) ?? null;
        }
    }
}
