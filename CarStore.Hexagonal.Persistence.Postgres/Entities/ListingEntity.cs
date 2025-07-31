using CarStore.Hexagonal.Persistence.Postgres.Entities.Base;

namespace CarStore.Hexagonal.Persistence.Postgres.Entities
{
    public class ListingEntity : BaseEntity<string>
    {
        public string CarId { get; set; }
        public CarEntity Car { get; set; }

        public string DealerId { get; set; }
        public UserEntity Dealer { get; set; }

        public decimal ListedPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }

        public ICollection<OfferEntity> Offers { get; set; } = [];
        public ICollection<TestDriveRequestEntity> TestDrives { get; set; } = [];
    }
}
