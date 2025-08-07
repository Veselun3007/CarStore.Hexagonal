using Grpc.Core;
using MediatR;
using CarStore.Hexagonal.Application.Features.Cars.Queries.GetAllCar;
using CarStore.Hexagonal.Application.Features.Cars.Queries.GetCarById;
using CarStore.Hexagonal.Application.Features.Cars.Commands.DeleteCar;
using CarStore.Hexagonal.Presentation.Grpc.Mappers;

namespace CarStore.Hexagonal.Presentation.Grpc.Services
{
    public class CarService : CarGrpcService.CarGrpcServiceBase
    {
        private readonly IMediator _mediator;

        public CarService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<GetAllCarsResponse> GetAllCars(GetAllCarsRequest request, ServerCallContext context)
        {
            var result = await _mediator.Send(new GetAllCarQuery());
            if(!result.Any())
            {
                throw new RpcException(new Status(StatusCode.NotFound, "No cars found"));
            }

            var response = new GetAllCarsResponse();
            response.Cars.AddRange(result.Select(CarGrpcMapper.ToGrpcDto));
            return response;
        }

        public override async Task<CarResponse> GetCarById(GetCarByIdRequest request, ServerCallContext context)
        {
            var result = await _mediator.Send(new GetCarByIdQuery { CarId = request.CarId });
            return result is null
                ? throw new RpcException(new Status(StatusCode.NotFound, $"Car with ID '{request.CarId}' not found"))
                : CarGrpcMapper.ToGrpcDto(result);
        }

        public override async Task<CarResponse> AddCar(AddCarRequest request, ServerCallContext context)
        {
            var addCar = CarGrpcMapper.ToCommand(request);
            var result = await _mediator.Send(addCar);
            return CarGrpcMapper.ToGrpcDto(result);
        }

        public override async Task<DeleteCarResponse> DeleteCar(DeleteCarRequest request, ServerCallContext context)
        {
            var result = await _mediator.Send(new DeleteCarCommand { CarId = request.CarId });
            return result is null
                ? throw new RpcException(new Status(StatusCode.NotFound, $"Car with ID '{request.CarId}' not found"))
                : new DeleteCarResponse { Message = "Deleted succesful" };
        }       
    }
}
