using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.AcceptOffer
{
    internal class AcceptOfferHandler : IRequestHandler<AcceptOfferCommand, ListingResult>
    {
        private readonly IRepository<Listing, string> _repo;

        public AcceptOfferHandler(IRepository<Listing, string> repo) 
        { 
            _repo = repo; 
        }

        public async Task<ListingResult> Handle(AcceptOfferCommand request, CancellationToken cancellationToken)
        {
            var listing = await _repo.FindByIdAsync(request.ListingId);
            listing.AcceptOffer(request.CustomerId);
            await _repo.UpdateAsync(listing.Id, listing);
            return ListingResult.FromEntity(listing);
        }
    }
}
