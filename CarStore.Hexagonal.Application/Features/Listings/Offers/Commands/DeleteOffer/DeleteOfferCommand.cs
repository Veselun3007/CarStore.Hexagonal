using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.DeleteOffer
{
    public class DeleteOfferCommand : IRequest<ListingResult>
    {
        public string OfferId { get; set; }
        public string ListingId { get; set; }
    }
}
