using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Domain.Enums;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Commands.UpdateListing
{
    public class UpdateListingCommand : IRequest<ListingResult>
    {
        public string ListingId { get; set; }
        public string CarId { get; set; }
        public string DealerId { get; set; }
        public decimal ListedPrice { get; set; }
        public string Description { get; set; }
        public decimal? Discount { get; set; }
    }
}
