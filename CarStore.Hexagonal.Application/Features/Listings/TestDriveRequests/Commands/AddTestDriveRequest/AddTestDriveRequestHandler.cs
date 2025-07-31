using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Interfaces;
using CarStore.Hexagonal.Domain.Entities;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.TestDriveRequests.Commands.AddTestDriveRequest
{
    internal class AddTestDriveRequestHandler : IRequestHandler<AddTestDriveRequestCommand, ListingResult>
    {
        private readonly IRepository<Listing, string> _repo;

        public AddTestDriveRequestHandler(IRepository<Listing, string> repo)
        {
            _repo = repo;
        }

        public async Task<ListingResult> Handle(AddTestDriveRequestCommand request, CancellationToken cancellationToken)
        {
            var listing = await _repo.FindByIdAsync(request.ListingId);
            var testDrive = new TestDriveRequest(request.ListingId, request.CustomerId, request.RequestedDate);
            listing.RequestTestDrive(testDrive);
            var updatedListing = await _repo.UpdateAsync(request.ListingId, listing);
            return ListingResult.FromEntity(updatedListing);
        }
    }
}
