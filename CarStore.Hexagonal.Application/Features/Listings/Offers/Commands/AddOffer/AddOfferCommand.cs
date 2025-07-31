using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.AddOffer
{
    public class AddOfferCommand : IRequest<ListingResult>
    {
        public string ListingId { get; set; }
        public string CustomerId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
