using CarStore.Hexagonal.Application.Features.Cars.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Cars.Queries.GetCarById
{
    internal class GetCarByIdHandler : IRequestHandler<GetCarByIdQuery, CarResult?>
    {
        private readonly IRepository<Car, string> _repo;

        public GetCarByIdHandler(IRepository<Car, string> repository)
        {
            _repo = repository;
        }

        public async Task<CarResult?> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _repo.FindByIdAsync(request.CarId);
            return CarResult.FromEntity(car) ?? null;
        }
    }
}
