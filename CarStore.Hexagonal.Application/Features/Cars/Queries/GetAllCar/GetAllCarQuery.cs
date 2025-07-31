using CarStore.Hexagonal.Application.Features.Cars.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Cars.Queries.GetAllCar
{
    public class GetAllCarQuery : IRequest<IEnumerable<CarResult>> { }
}
