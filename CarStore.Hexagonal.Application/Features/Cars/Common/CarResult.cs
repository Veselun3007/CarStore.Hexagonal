using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;
using HotChocolate;

namespace CarStore.Hexagonal.Application.Features.Cars.Common
{
    public class CarResult
    {
        [GraphQLName("carId")]
        public string CarId { get; set; }

        [GraphQLName("make")]
        public string Make { get; set; }

        [GraphQLName("model")]
        public string Model { get; set; }

        [GraphQLName("vin")]
        public string Vin { get; set; }

        [GraphQLName("priceUsd")]
        public decimal PriceUsd { get; set; }

        [GraphQLName("priceUah")]
        public decimal PriceUah { get; set; }

        public static CarResult FromEntity(Car car)
        {
            return new CarResult
            {
                CarId = car.Id,
                Make = car.Make,
                Model = car.Model,
                Vin = car.Vin.Value,
                PriceUsd = car.Price.Amount,
                PriceUah = car.Price.ConvertTo(Currency.UAH).Amount
            };
        }
    }
}
