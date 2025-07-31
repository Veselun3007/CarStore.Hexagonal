using CarStore.Hexagonal.Application.Features.Cars.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Cars.Queries.GetAllCar
{
    internal class GetAllCarHandler : IRequestHandler<GetAllCarQuery, IEnumerable<CarResult>>
    {
        private readonly IRepository<Car, string> _repo;

        public GetAllCarHandler(IRepository<Car, string> repository)
        {
            _repo = repository;
        }

        public async Task<IEnumerable<CarResult>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            var users = await _repo.GetAllAsync();
            return users?.Select(CarResult.FromEntity) ?? [];
        }
    }
}
