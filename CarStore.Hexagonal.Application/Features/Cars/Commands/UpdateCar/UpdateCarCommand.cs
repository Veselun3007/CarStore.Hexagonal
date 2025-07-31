using CarStore.Hexagonal.Application.Features.Cars.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Cars.Commands.UpdateCar
{
    public class UpdateCarCommand : IRequest<CarResult>
    {
        public string CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Vin { get; set; }
        public decimal Price { get; set; }
    }
}
