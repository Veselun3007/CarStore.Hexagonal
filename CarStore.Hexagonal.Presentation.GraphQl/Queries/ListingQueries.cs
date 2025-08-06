using CarStore.Hexagonal.Application.Features.Listings.Common;
using CarStore.Hexagonal.Application.Features.Listings.Queries.GetAllListing;
using CarStore.Hexagonal.Application.Features.Listings.Queries.GetListingById;
using MediatR;

namespace CarStore.Hexagonal.Presentation.GraphQl.Queries
{
    public class ListingQueries
    {
        public async Task<IEnumerable<ListingResult>?> GetAllListings([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllListingQuery(), cancellationToken);
            return result;
        }

        public async Task<ListingResult?> GetListingById([Service] IMediator mediator, string listingId, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetListingByIdQuery { ListingId = listingId }, cancellationToken);
            return result;
        }
    }
}
