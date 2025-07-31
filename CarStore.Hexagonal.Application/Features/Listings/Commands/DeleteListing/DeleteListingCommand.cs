using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Commands.DeleteListing
{
    public class DeleteListingCommand : IRequest<string>
    {
        public string ListingId { get; set; }
    }
}
