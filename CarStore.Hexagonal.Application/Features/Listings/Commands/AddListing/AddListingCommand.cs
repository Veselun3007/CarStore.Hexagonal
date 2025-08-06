using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Commands.AddListing
{
    public class AddListingCommand : IRequest<AddListingResult>
    {
        public string CarId { get; set; }
        public string DealerId { get; set; }
        public decimal ListedPrice { get; set; }
        public string Description { get; set; }
        public decimal? Discount { get; set; }
    }
}
