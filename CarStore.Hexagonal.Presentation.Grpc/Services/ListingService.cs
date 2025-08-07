using CarStore.Hexagonal.Application.Features.Listings.Commands.DeleteListing;
using CarStore.Hexagonal.Application.Features.Listings.Queries.GetAllListing;
using CarStore.Hexagonal.Application.Features.Listings.Queries.GetListingById;
using CarStore.Hexagonal.Presentation.Grpc.Mappers;
using Grpc.Core;
using MediatR;

namespace CarStore.Hexagonal.Presentation.Grpc.Services
{
    public class ListingService : ListingGrpcService.ListingGrpcServiceBase
    {
        private readonly IMediator _mediator;

        public ListingService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<GetAllListingsResponse> GetAllListing(GetAllListingRequest request, ServerCallContext context)
        {
            var result = await _mediator.Send(new GetAllListingQuery());
            if(!result.Any())
            {
                throw new RpcException(new Status(StatusCode.NotFound, "No listings found"));
            }

            var response = new GetAllListingsResponse();
            response.Listings.AddRange(result.Select(ListingGrpcMapper.ToGrpcDto));
            return response;
        }

        public override async Task<ListingResponse> GetListingById(GetListingByIdRequest request, ServerCallContext context)
        {
            var result = await _mediator.Send(new GetListingByIdQuery { ListingId = request.ListingId });
            return result is null
                ? throw new RpcException(new Status(StatusCode.NotFound, $"Listing with ID '{request.ListingId}' not found"))
                : ListingGrpcMapper.ToGrpcDto(result);
        }

        public override async Task<ListingResponse> AddListing(AddListingRequest request, ServerCallContext context)
        {
            var command = ListingGrpcMapper.ToCommand(request);
            var result = await _mediator.Send(command);
            return ListingGrpcMapper.ToGrpcDto(result);
        }

        public override async Task<DeleteListingResponse> DeleteListing(DeleteListingRequest request, ServerCallContext context)
        {
            var result = await _mediator.Send(new DeleteListingCommand { ListingId = request.ListingId });
            return result is null
                ? throw new RpcException(new Status(StatusCode.NotFound, $"Listing with ID '{request.ListingId}' not found"))
                : new DeleteListingResponse { Message = "Deleted successful" };
        }      
    }
}
