using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Queries.GetListingById
{
    internal class GetListingByIdHandler : IRequestHandler<GetListingByIdQuery, ListingResult?>
    {
        private readonly IRepository<Listing, string> _repo;

        public GetListingByIdHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<ListingResult?> Handle(GetListingByIdQuery request, CancellationToken cancellationToken)
        {
            var listing = await _repo.FindByIdAsync(request.ListingId);
            return ListingResult.FromEntity(listing) ?? null;
        }
    }
}
