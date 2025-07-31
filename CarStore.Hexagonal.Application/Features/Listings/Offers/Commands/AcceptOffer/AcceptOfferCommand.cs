using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.AcceptOffer
{
    public class AcceptOfferCommand : IRequest<ListingResult>
    {
        public string ListingId { get; set; }
        public string CustomerId { get; set; }
    }
}
