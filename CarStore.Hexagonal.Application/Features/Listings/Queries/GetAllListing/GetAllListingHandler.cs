using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Queries.GetAllListing
{
    internal class GetAllListingHandler : IRequestHandler<GetAllListingQuery, IEnumerable<ListingResult>?>
    {
        private readonly IRepository<Listing, string> _repo;

        public GetAllListingHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ListingResult>?> Handle(GetAllListingQuery request, CancellationToken cancellationToken)
        {
            var listings = await _repo.GetAllAsync();
            return listings?.Select(ListingResult.FromEntity) ?? [];
        }
    }
}
