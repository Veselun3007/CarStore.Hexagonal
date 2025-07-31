using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.TestDriveRequests.Commands.ApproveTestDrive
{
    public class ApproveTestDriveCommand : IRequest<ListingResult>
    {
        public string ListingId { get; set; }
        public string CustomerId { get; set; }
    }
}
