using CarStore.Hexagonal.Application.Features.Listings.Common;
using MediatR;

namespace CarStore.Hexagonal.Application.Features.Listings.Queries.GetAllListing
{
    public class GetAllListingQuery : IRequest<IEnumerable<ListingResult>> { }
}
