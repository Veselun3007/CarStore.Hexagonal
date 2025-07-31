using CarStore.Hexagonal.Persistence.Postgres.Entities.Base;

namespace CarStore.Hexagonal.Persistence.Postgres.Entities
{
    public class OfferEntity : BaseEntity<string>
    {
        public string ListingId { get; set; }
        public ListingEntity Listing { get; set; }

        public string CustomerId { get; set; }
        public UserEntity Customer { get; set; }

        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int State { get; set; }
    }
}
