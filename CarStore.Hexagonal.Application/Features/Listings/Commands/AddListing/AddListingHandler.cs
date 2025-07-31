using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Commands.AddListing
{
    internal class AddListingHandler : IRequestHandler<AddListingCommand, AddListingResult>
    {
        private readonly IRepository<Listing, string> _repo;

        public AddListingHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<AddListingResult> Handle(AddListingCommand request, CancellationToken cancellationToken)
        {
            var listing = new Listing(request.CarId,
                                      request.DealerId,
                                      new(request.ListedPrice, Domain.Enums.Currency.USD, request.Discount),
                                      new(request.Description));
            var createdListing = await _repo.AddAsync(listing);
            return AddListingResult.FromEntity(createdListing);
        }
    }
}
