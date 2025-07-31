using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;
using CarStore.Hexagonal.Domain.ValueObjects;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using CarStore.Hexagonal.Persistence.Postgres.Mapping.Base;
using Riok.Mapperly.Abstractions;

namespace CarStore.Hexagonal.Persistence.Postgres.Mapping
{
    [Mapper]
    public partial class CarMapper : IEntityMapper<Car, CarEntity>
    {
        public partial CarEntity ToEntity(Car car);
        public partial Car ToDomain(CarEntity entity);

        private string MapVin(VinCode vin) => vin.Value;
        private VinCode MapVin(string vin) => new(vin);

        private decimal MapMoney(Money money) => money.FinalAmount;
        private Money MapMoney(decimal amount) => new(amount, Currency.USD);
    }
}
