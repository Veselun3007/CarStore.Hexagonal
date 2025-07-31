using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;
using CarStore.Hexagonal.Domain.ValueObjects;
using CarStore.Hexagonal.Persistence.Postgres.Entities;
using CarStore.Hexagonal.Persistence.Postgres.Mapping.Base;
using Riok.Mapperly.Abstractions;

namespace CarStore.Hexagonal.Persistence.Postgres.Mapping;

[Mapper]
public partial class ListingMapper : IEntityMapper<Listing, ListingEntity>
{
    [UseMapper]
    private readonly OfferMapper _offerMapper = new();

    [UseMapper]
    private readonly TestDriveRequestMapper _testDriveMapper = new();

    public partial ListingEntity ToEntity(Listing listing);
    public partial Listing ToDomain(ListingEntity entity);

    private int MapStatus(ListingStatus status) => (int)status;
    private ListingStatus MapStatus(int value) => (ListingStatus)value;


    [MapProperty(nameof(Listing.ListedPrice), nameof(ListingEntity.ListedPrice))]
    private decimal MapMoney(Money money) => money.FinalAmount;

    [MapProperty(nameof(ListingEntity.ListedPrice), nameof(Listing.ListedPrice))]
    private Money MapMoney(decimal amount) => new(amount, Currency.USD);

    [MapProperty(nameof(Listing.Description), nameof(ListingEntity.Description))]
    private string MapDescription(CarDescription desc) => desc.Value;

    [MapProperty(nameof(ListingEntity.Description), nameof(Listing.Description))]
    private CarDescription MapDescription(string value) => new(value);


    [MapProperty(nameof(ListingEntity.Offers), nameof(Listing.Offers))]
    private ICollection<Offer> MapEntityToDomainOffers(ICollection<OfferEntity> offers) =>
    offers?.Select(_offerMapper.ToDomain).ToList() ?? [];

    [MapProperty(nameof(Listing.Offers), nameof(ListingEntity.Offers))]
    private ICollection<OfferEntity> MapDomainToEntityOffers(IReadOnlyCollection<Offer> offers) =>
        offers?.Select(_offerMapper.ToEntity).ToList() ?? [];

    [MapProperty(nameof(ListingEntity.TestDrives), nameof(Listing.TestDriveRequests))]
    private ICollection<TestDriveRequest> MapEntityToDomainDrives(ICollection<TestDriveRequestEntity> drives) =>
    drives?.Select(_testDriveMapper.ToDomain).ToList() ?? [];

    [MapProperty(nameof(Listing.TestDriveRequests), nameof(ListingEntity.TestDrives))]
    private ICollection<TestDriveRequestEntity> MapDomainToEntityDrives(IReadOnlyCollection<TestDriveRequest> drives) =>
        drives?.Select(_testDriveMapper.ToEntity).ToList() ?? [];
}
