using CarStore.Hexagonal.Application.Features.Cars.Commands.AddCar;
using CarStore.Hexagonal.Application.Features.Cars.Common;

namespace CarStore.Hexagonal.Presentation.Grpc.Mappers
{
    public static class CarGrpcMapper
    {
        public static AddCarCommand ToCommand(AddCarRequest request)
        {
            return new AddCarCommand
            {
                Make = request.Make,
                Model = request.Model,
                Vin = request.Vin,
                Price = (decimal)request.Price,
            };
        }

        public static CarResponse ToGrpcDto(CarResult result)
        {
            return new CarResponse
            {
                CarId = result.CarId,
                Make = result.Make,
                Model = result.Model,
                Vin = result.Vin,
                PriceUsd = (double)result.PriceUsd,
                PriceUah = (double)result.PriceUah
            };
        }
    }
}
