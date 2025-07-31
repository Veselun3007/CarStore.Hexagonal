using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;
using CarStore.Hexagonal.Domain.ValueObjects;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using CarStore.Hexagonal.Persistence.Postgres.Mapping.Base;
using Riok.Mapperly.Abstractions;

namespace CarStore.Hexagonal.Persistence.Postgres.Mapping
{
    [Mapper]
    public partial class OfferMapper : IEntityMapper<Offer, OfferEntity>
    {
        public partial OfferEntity ToEntity(Offer offer);
        public partial Offer ToDomain(OfferEntity entity);

        private decimal MapMoney(Money money) => money.FinalAmount;
        private Money MapMoney(decimal amount) => new(amount, Currency.USD);
    }
}
