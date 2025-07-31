using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.DeclineOffer
{
    internal class DeclineOfferHandler : IRequestHandler<DeclineOfferCommand, ListingResult>
    {
        private readonly IRepository<Listing, string> _repo;

        public DeclineOfferHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<ListingResult> Handle(DeclineOfferCommand request, CancellationToken cancellationToken)
        {
            var listing = await _repo.FindByIdAsync(request.ListingId)
                ?? throw new KeyNotFoundException("Listing not found.");

            var offer = listing.Offers.FirstOrDefault(td => td.CustomerId == request.CustomerId)
                ?? throw new KeyNotFoundException("Test drive request not found.");

            offer.Decline();

            var updatedListing = await _repo.UpdateAsync(listing.Id, listing);
            return ListingResult.FromEntity(updatedListing);
        }
    }
}
