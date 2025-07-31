namespace CarStore.Hexagonal.Domain
{
    public class OfferAccepted
    {
        public string ListingId { get; init; }
        public string OfferId { get; init; }
        public string CustomerId { get; init; }
        public DateTime AcceptedAt { get; init; }
    }
}
