using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Commands.UpdateListing
{
    internal class UpdateListingHandler : IRequestHandler<UpdateListingCommand, ListingResult>
    {
        private readonly IRepository<Listing, string> _repo;

        public UpdateListingHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<ListingResult> Handle(UpdateListingCommand request, CancellationToken cancellationToken)
        {
            var listing = new Listing(request.ListingId,
                                      request.CarId,
                                      request.DealerId,
                                      new(request.ListedPrice, Domain.Enums.Currency.USD, request.Discount),
                                      new(request.Description));
            var updatedListing = await _repo.UpdateAsync(request.ListingId, listing);
            return ListingResult.FromEntity(updatedListing);
        }
    }
}
