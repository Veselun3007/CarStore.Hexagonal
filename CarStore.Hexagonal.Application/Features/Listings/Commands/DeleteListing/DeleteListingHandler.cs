using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Commands.DeleteListing
{
    internal class DeleteListingHandler : IRequestHandler<DeleteListingCommand, string>
    {
        private readonly IRepository<Listing, string> _repo;

        public DeleteListingHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(DeleteListingCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.ListingId);
            return "Listing success deleted";
        }
    }
}
