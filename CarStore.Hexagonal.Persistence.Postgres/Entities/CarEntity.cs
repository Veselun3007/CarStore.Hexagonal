using CarStore.Hexagonal.Persistence.Postgres.Entities.Base;

namespace CarStore.Hexagonal.Persistence.Postgres.Entities
{
    public class CarEntity : BaseEntity<string>
    {
        public string Make { get; set; }
        public string Model { get; set; }

        public string Vin { get; set; }
        public decimal Price { get; set; }

        public ListingEntity? Listing { get; set; }
    }
}
