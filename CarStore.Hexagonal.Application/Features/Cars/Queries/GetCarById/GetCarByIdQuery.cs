using CarStore.Hexagonal.Application.Features.Cars.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Cars.Queries.GetCarById;

public class GetCarByIdQuery : IRequest<CarResult>
{
    public string CarId { get; set; }
}
