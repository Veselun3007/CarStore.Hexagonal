using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.AddOffer
{
    internal class AddOfferHandler : IRequestHandler<AddOfferCommand, ListingResult>
    {
        private readonly IRepository<Listing, string> _repo;

        public AddOfferHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<ListingResult> Handle(AddOfferCommand request, CancellationToken cancellationToken)
        {
            var listing = await _repo.FindByIdAsync(request.ListingId);
            var offer = new Offer(request.CustomerId, new(request.Price, Currency.USD, request.Discount));
            listing.AddOffer(offer);
            var updatedListing = await _repo.UpdateAsync(request.ListingId, listing);
            return ListingResult.FromEntity(updatedListing);
        }
    }
}
