using CarStore.Hexagonal.Persistence.Postgres.Entities.Base;

namespace CarStore.Hexagonal.Persistence.Postgres.Entities
{
    public class UserEntity : BaseEntity<string>
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public ICollection<ListingEntity> Listings { get; set; } = [];
        public ICollection<OfferEntity> Offers { get; set; } = [];
        public ICollection<TestDriveRequestEntity> TestDriveRequests { get; set; } = [];
    }
}
