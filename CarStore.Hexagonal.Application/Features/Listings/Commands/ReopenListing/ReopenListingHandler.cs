using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Commands.ReopenListing
{
    public class ReopenListingHandler : IRequestHandler<ReopenListingCommand, ListingResult>
    {
        private readonly IRepository<Listing, string> _repo;

        public ReopenListingHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<ListingResult> Handle(ReopenListingCommand request, CancellationToken cancellationToken)
        {
            var listing = await _repo.FindByIdAsync(request.ListingId);
            listing.Reopen();
            var updatedListing = await _repo.UpdateAsync(request.ListingId, listing);
            return ListingResult.FromEntity(updatedListing);
        }
    }
}
