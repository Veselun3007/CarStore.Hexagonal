using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;

namespace CarStore.Hexagonal.Application.Features.Cars.Common
{
    public class CarResult
    {
        public string CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Vin { get; set; }
        public decimal PriceUsd { get; set; }
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
                PriceUah = car.Price.ConvertTo(Currency.UAH, Currency.USD).Amount
            };
        }
    }
}
