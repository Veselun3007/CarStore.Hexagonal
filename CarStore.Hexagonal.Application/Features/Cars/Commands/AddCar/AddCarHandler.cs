using CarStore.Hexagonal.Application.Features.Cars.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Cars.Commands.AddCar
{
    internal class AddCarHandler : IRequestHandler<AddCarCommand, CarResult>
    {
        private readonly IRepository<Car, string> _repo;

        public AddCarHandler(IRepository<Car, string> repo)
        {
            _repo = repo;
        }

        public async Task<CarResult> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Car(request.Make,
                              request.Model,
                              new(request.Vin),
                              new(request.Price, Currency.USD));

            var createdCar = await _repo.AddAsync(car);
            return CarResult.FromEntity(createdCar);
        }
    }
}
