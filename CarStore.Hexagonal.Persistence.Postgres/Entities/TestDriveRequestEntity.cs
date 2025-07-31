using CarStore.Hexagonal.Persistence.Postgres.Entities.Base;

namespace CarStore.Hexagonal.Persistence.Postgres.Entities
{
    public class TestDriveRequestEntity : BaseEntity<string>
    {
        public string ListingId { get; set; }
        public ListingEntity Listing { get; set; }

        public string CustomerId { get; set; }
        public UserEntity Customer { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime RequestedDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
