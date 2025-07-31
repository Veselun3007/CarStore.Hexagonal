using CarStore.Hexagonal.Domain.Base;

namespace CarStore.Hexagonal.Domain.Entities
{
    public class TestDriveRequest : Entity<string>
    {
        public string ListingId { get; private set; }
        public string CustomerId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime RequestedDate { get; private set; }
        public bool IsApproved { get; private set; }

        public TestDriveRequest(string listingId, string customerId, DateTime requestedDate)
        {
            Id = Guid.NewGuid().ToString();
            ListingId = listingId;
            CustomerId = customerId;
            RequestedDate = requestedDate;
            CreatedAt = DateTime.UtcNow;
            IsApproved = false;
        }

        internal TestDriveRequest(string testDriveId, string listingId, string customerId, 
            DateTime requestedDate, DateTime createdAt, bool isApprove)
        {
            Id = testDriveId;
            ListingId = listingId;
            CustomerId = customerId;
            RequestedDate = requestedDate;
            CreatedAt = createdAt;
            IsApproved = isApprove;
        }

        public void Approve()
        {
            if(IsApproved)
            {
                throw new InvalidOperationException("Request already approved.");
            }

            if(RequestedDate < DateTime.UtcNow.Date)
            {
                throw new InvalidOperationException("Cannot approve a test drive in the past.");
            }

            IsApproved = true;
        }
    }
}
