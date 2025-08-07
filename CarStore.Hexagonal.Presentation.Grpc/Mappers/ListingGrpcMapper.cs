using CarStore.Hexagonal.Application.Features.Listings.Commands.AddListing;
using CarStore.Hexagonal.Application.Features.Listings.Common;

namespace CarStore.Hexagonal.Presentation.Grpc.Mappers
{
    public static class ListingGrpcMapper
    {
        public static AddListingCommand ToCommand(AddListingRequest request)
        {
            return new AddListingCommand
            {
                CarId = request.CarId,
                DealerId = request.DealerId,
                ListedPrice = (decimal)request.ListedPrice,
                Description = request.Description,
                Discount = request.Discount != 0 ? (decimal?)request.Discount : null
            };
        }

        public static ListingResponse ToGrpcDto(AddListingResult result)
        {
            return new ListingResponse
            {
                ListingId = result.ListingId,
                CarId = result.CarId,
                DealerId = result.DealerId,
                ListedPrice = (double)result.ListedPrice,
                Description = result.Description,
                CreatedAt = result.CreatedAt.ToString("o"),
                Status = result.Status.ToString()
            };
        }

        public static ListingResponse ToGrpcDto(ListingResult result)
        {
            var response = new ListingResponse
            {
                ListingId = result.ListingId,
                CarId = result.CarId,
                DealerId = result.DealerId,
                ListedPrice = (double)result.ListedPrice,
                Description = result.Description,
                CreatedAt = result.CreatedAt.ToString("o"),
                Status = result.Status.ToString()
            };

            if(result.Offers is not null)
            {
                response.Offers.AddRange(result.Offers.Select(o => new Offer
                {
                    OfferId = o.OfferId,
                    CustomerId = o.CustomerId,
                    CreatedAt = o.CreatedAt.ToString("o"),
                    Price = (double)o.Price,
                    Status = o.Status.ToString()
                }));
            }

            if(result.TestDrives is not null)
            {
                response.TestDrives.AddRange(result.TestDrives.Select(t => new TestDriveRequest
                {
                    TestDriveRequestId = t.TestDriveRequestId,
                    ListingId = t.ListingId,
                    CustomerId = t.CustomerId,
                    CreatedAt = t.CreatedAt.ToString("o"),
                    RequestedDate = t.RequestedDate.ToString("o"),
                    IsApproved = t.IsApproved
                }));
            }

            return response;
        }
    }
}
