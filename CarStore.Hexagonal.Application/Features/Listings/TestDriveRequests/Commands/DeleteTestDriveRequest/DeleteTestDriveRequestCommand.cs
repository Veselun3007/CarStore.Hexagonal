using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.TestDriveRequests.Commands.DeleteTestDriveRequest
{
    public class DeleteTestDriveRequestCommand : IRequest<ListingResult>
    {
        public string TestDriveRequestId { get; set; }
        public string ListingId { get; set; }
    }
}
