using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;

namespace CarStore.Hexagonal.Application.Features.Listings.Common
{
    public class ListingResult
    {
        public string ListingId { get; set; }
        public string CarId { get; set; }
        public string DealerId { get; set; }
        public decimal ListedPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public ListingStatus Status { get; set; }
        public string Description { get; set; }
        public IEnumerable<OfferResult>? Offers { get; set; }
        public IEnumerable<TestDriveRequestResult>? TestDrives { get; set; }

        public static ListingResult FromEntity(Listing listing)
        {
            return new ListingResult
            {
                ListingId = listing.Id,
                CarId = listing.CarId,
                DealerId = listing.DealerId,
                CreatedAt = listing.CreatedAt,
                ListedPrice = listing.ListedPrice.Amount,
                Status = listing.Status,
                Description = listing.Description.Value,
                Offers = listing.Offers.Select(OfferResult.FromEntity),
                TestDrives = listing.TestDriveRequests.Select(TestDriveRequestResult.FromEntity)
            };
        }
    }
}
