using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.TestDriveRequests.Commands.DeleteTestDriveRequest
{
    internal class DeleteTestDriveRequestHandler : IRequestHandler<DeleteTestDriveRequestCommand, ListingResult>
    {
        private readonly IRepository<Listing, string> _repo;

        public DeleteTestDriveRequestHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<ListingResult> Handle(DeleteTestDriveRequestCommand request, CancellationToken cancellationToken)
        {
            var listing = await _repo.FindByIdAsync(request.ListingId);
            listing.RecallTestDrive(request.TestDriveRequestId);
            var updatedListing = await _repo.UpdateAsync(request.ListingId, listing);
            return ListingResult.FromEntity(updatedListing);
        }
    }
}

