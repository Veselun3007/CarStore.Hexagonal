using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Commands.PostListing
{
    public class PostListingCommand : IRequest<ListingResult>
    {
        public string ListingId { get; set; }
    }
}
