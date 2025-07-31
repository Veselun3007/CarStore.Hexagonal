using CarStore.Hexagonal.Domain.Base;
using CarStore.Hexagonal.Domain.Enums;
using CarStore.Hexagonal.Domain.ValueObjects;

namespace CarStore.Hexagonal.Domain.Entities
{
    public class Offer : Entity<string>
    {
        public string CustomerId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Money Price { get; private set; }
        public OfferStatus Status { get; private set; }

        public Offer(string customerId, Money price)
        {
            Id = Guid.NewGuid().ToString();
            CustomerId = customerId;
            CreatedAt = DateTime.UtcNow;
            Status = OfferStatus.Pending;
            Price = price;
        }

        internal Offer(string offerId, string customerId, Money price, 
            DateTime createdAt, OfferStatus status)
        {
            Id = offerId;
            CustomerId = customerId;
            CreatedAt = createdAt;
            Status = status;
            Price = price;
        }


        public bool IsRecent(int days) => CreatedAt >= DateTime.UtcNow.AddDays(-days);

        public void Accept()
        {
            if(Status == OfferStatus.Accepted)
            {
                throw new InvalidOperationException("Offer already accepted.");
            }

            Status = OfferStatus.Accepted;
        }

        public void Decline()
        {
            if(Status == OfferStatus.Decline)
            {
                return;
            }

            Status = OfferStatus.Decline;
        }
    }
}
