using CarStore.Hexagonal.Application.Features.Cars.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Cars.Commands.UpdateCar
{
    internal class UpdateCarHandler : IRequestHandler<UpdateCarCommand, CarResult>
    {
        private readonly IRepository<Car, string> _repo;

        public UpdateCarHandler(IRepository<Car, string> repo)
        {
            _repo = repo;
        }

        public async Task<CarResult> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Car(request.CarId,
                              request.Make,
                              request.Model,
                              new(request.Vin),
                              new(request.Price, Currency.USD));

            var createdCar = await _repo.UpdateAsync(request.CarId, car);
            return CarResult.FromEntity(createdCar);
        }
    }
}

