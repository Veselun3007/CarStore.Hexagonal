using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;
using HotChocolate;

namespace CarStore.Hexagonal.Application.Features.Listings.Common
{
    public class ListingResult
    {
        [GraphQLName("listingId")]
        public string ListingId { get; set; }

        [GraphQLName("carId")]
        public string CarId { get; set; }

        [GraphQLName("dealerId")]
        public string DealerId { get; set; }

        [GraphQLName("listedPrice")]
        public decimal ListedPrice { get; set; }

        [GraphQLName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [GraphQLName("status")]
        public ListingStatus Status { get; set; }

        [GraphQLName("description")]
        public string Description { get; set; }

        [GraphQLName("offers")]
        public IEnumerable<OfferResult>? Offers { get; set; }

        [GraphQLName("testDrives")]
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
                Offers = listing.Offers?.Select(OfferResult.FromEntity) ?? [],
                TestDrives = listing.TestDriveRequests?.Select(TestDriveRequestResult.FromEntity) ?? [],
            };
        }
    }
}
