using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;

namespace CarStore.Hexagonal.Application.Features.Listings.Common
{
    public class OfferResult
    {
        public string OfferId { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
        public OfferStatus Status { get; set; }

        public static OfferResult? FromEntity(Offer offer)
        {
            return new OfferResult
            {
                OfferId = offer.Id,
                CustomerId = offer.CustomerId,
                CreatedAt = offer.CreatedAt,
                Price = offer.Price.Amount,
                Status = offer.Status,
            };
        }
    }
}
