using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Queries.GetListingById
{
    public class GetListingByIdQuery : IRequest<ListingResult>
    {
        public string ListingId { get; set; }
    }
}
