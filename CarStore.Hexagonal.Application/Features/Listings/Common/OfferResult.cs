using CarStore.Hexagonal.Domain.Entities;
using CarStore.Hexagonal.Domain.Enums;
using HotChocolate;

namespace CarStore.Hexagonal.Application.Features.Listings.Common
{
    public class OfferResult
    {
        [GraphQLName("offerId")]
        public string OfferId { get; set; }

        [GraphQLName("customerId")]
        public string CustomerId { get; set; }

        [GraphQLName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [GraphQLName("price")]
        public decimal Price { get; set; }

        [GraphQLName("status")]
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
