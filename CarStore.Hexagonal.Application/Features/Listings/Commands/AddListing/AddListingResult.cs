using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;

namespace CarStore.Hexagonal.Application.Features.Listings.Commands.AddListing
{
    public class AddListingResult
    {
        public string ListingId { get; set; }
        public string CarId { get; set; }
        public string DealerId { get; set; }
        public decimal ListedPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public ListingStatus Status { get; set; }
        public string Description { get; set; }

        public static AddListingResult FromEntity(Listing listing)
        {
            return new AddListingResult
            {
                ListingId = listing.Id,
                CarId = listing.CarId,
                DealerId = listing.DealerId,
                CreatedAt = listing.CreatedAt,
                Status = listing.Status,
                Description = listing.Description.Value
            };
        }
    }
}
