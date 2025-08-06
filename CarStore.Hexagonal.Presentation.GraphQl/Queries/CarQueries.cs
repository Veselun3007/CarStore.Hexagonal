using CarStore.Hexagonal.Application.Features.Cars.Common;
using CarStore.Hexagonal.Application.Features.Cars.Queries.GetAllCar;
using CarStore.Hexagonal.Application.Features.Cars.Queries.GetCarById;
using MediatR;

namespace CarStore.Hexagonal.Presentation.GraphQl.Queries
{
    public class CarQueries
    {
        public async Task<IEnumerable<CarResult>?> GetCarsAsync([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetAllCarQuery(), cancellationToken);
        }

        public async Task<CarResult?> GetCarById([Service] IMediator mediator, string carId, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetCarByIdQuery { CarId = carId }, cancellationToken);
        }
    }
}
