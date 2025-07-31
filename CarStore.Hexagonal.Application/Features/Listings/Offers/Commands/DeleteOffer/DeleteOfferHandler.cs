using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.DeleteOffer
{
    internal class DeleteOfferHandler : IRequestHandler<DeleteOfferCommand, ListingResult>
    {
        private readonly IRepository<Listing, string> _repo;

        public DeleteOfferHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<ListingResult> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            var listing = await _repo.FindByIdAsync(request.ListingId);
            listing.RemoveOffer(request.OfferId);
            var updatedListing = await _repo.UpdateAsync(request.ListingId, listing);
            return ListingResult.FromEntity(updatedListing);
        }
    }
}
