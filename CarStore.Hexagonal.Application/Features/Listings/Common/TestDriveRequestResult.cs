using CarStore.Hexagonal.Domain.Entities;

namespace CarStore.Hexagonal.Application.Features.Listings.Common
{
    public class TestDriveRequestResult
    {
        public string TestDriveRequestId { get; set; }
        public string ListingId { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime RequestedDate { get; set; }
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
