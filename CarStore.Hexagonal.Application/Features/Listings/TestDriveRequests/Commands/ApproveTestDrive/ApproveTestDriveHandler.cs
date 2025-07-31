using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.TestDriveRequests.Commands.ApproveTestDrive
{
    internal class ApproveTestDriveHandler : IRequestHandler<ApproveTestDriveCommand, ListingResult>
    {
        private readonly IRepository<Listing, string> _repo;

        public ApproveTestDriveHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<ListingResult> Handle(ApproveTestDriveCommand request, CancellationToken cancellationToken)
        {
            var listing = await _repo.FindByIdAsync(request.ListingId) 
                ?? throw new KeyNotFoundException("Listing not found.");

            var testDrive = listing.TestDriveRequests.FirstOrDefault(td => td.CustomerId == request.CustomerId) 
                ?? throw new KeyNotFoundException("Test drive request not found.");

            testDrive.Approve();

            var updatedListing = await _repo.UpdateAsync(listing.Id, listing);
            return ListingResult.FromEntity(updatedListing);
        }
    }
}
