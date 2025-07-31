using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Commands.CancelListing
{
    public class CancelListingCommand : IRequest<ListingResult>
    {
        public string ListingId { get; set; }
    }
}
