using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.DeclineOffer
{
    public class DeclineOfferCommand : IRequest<ListingResult>
    {
        public string ListingId { get; set; }
        public string CustomerId { get; set; }
    }
}
