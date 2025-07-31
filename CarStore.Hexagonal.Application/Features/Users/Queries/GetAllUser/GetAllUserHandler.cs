using CarStore.Hexagonal.Application.Features.Users.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Users.Queries.GetAllUser
{
    internal class GetAllUserHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserResult>>
    {
        private readonly IRepository<User, string> _repo;

        public GetAllUserHandler(IRepository<User, string> repository)
        {
            _repo = repository;
        }

        public async Task<IEnumerable<UserResult>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _repo.GetAllAsync();
            return users?.Select(UserResult.FromEntity) ?? [];
        }
    }
}
