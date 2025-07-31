using MediatR;

namespace CarStore.Hexagonal.Application.Features.Cars.Commands.DeleteCar
{
    public class DeleteCarCommand : IRequest<string>
    {
        public string CarId { get; set; }
    }
}
