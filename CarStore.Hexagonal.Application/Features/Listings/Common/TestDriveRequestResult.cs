using CarStore.Hexagonal.Domain.Entities;
using HotChocolate;

namespace CarStore.Hexagonal.Application.Features.Listings.Common
{
    public class TestDriveRequestResult
    {
        [GraphQLName("testDriveRequestId")]
        public string TestDriveRequestId { get; set; }

        [GraphQLName("listingId")]
        public string ListingId { get; set; }

        [GraphQLName("customerId")]
        public string CustomerId { get; set; }

        [GraphQLName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [GraphQLName("requestedDate")]
        public DateTime RequestedDate { get; set; }

        [GraphQLName("isApproved")]
        public bool IsApproved { get; set; }

        public static TestDriveRequestResult? FromEntity(TestDriveRequest testDrive)
        {
            return new TestDriveRequestResult()
            {
                TestDriveRequestId = testDrive.Id,
                ListingId = testDrive.ListingId,
                CustomerId = testDrive.CustomerId,
                CreatedAt = testDrive.CreatedAt,
                RequestedDate = testDrive.RequestedDate,
                IsApproved = testDrive.IsApproved,
            };
        }
    }
}
