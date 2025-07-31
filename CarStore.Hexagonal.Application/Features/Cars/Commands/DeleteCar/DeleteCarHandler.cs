using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Cars.Commands.DeleteCar
{
    internal class DeleteCarHandler : IRequestHandler<DeleteCarCommand, string>
    {
        private readonly IRepository<Car, string> _repo;

        public DeleteCarHandler(IRepository<Car, string> repository)
        {
            _repo = repository;
        }

        public async Task<string> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.CarId);
            return "Car success deleted";
        }
    }
}

