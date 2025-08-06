using CarStore.Hexagonal.Application.Features.Cars.Commands.AddCar;
using CarStore.Hexagonal.Application.Features.Listings.Commands.AddListing;
using CarStore.Hexagonal.Application.Features.Users.Commands.AddUser;
using CarStore.Hexagonal.Application.Features.Cars.Common;
using CarStore.Hexagonal.Application.Features.Users.Common;
using MediatR;

namespace CarStore.Hexagonal.Presentation.GraphQl.Mutations
{
    public class Mutation
    {
        public async Task<UserResult> AddUserAsync(AddUserCommand command, [Service] IMediator mediator)
        {
            return await mediator.Send(command);
        }

        public async Task<CarResult> AddCarAsync( AddCarCommand command, [Service] IMediator mediator)
        {
            return await mediator.Send(command);
        }

        public async Task<AddListingResult> AddListingAsync(AddListingCommand command, [Service] IMediator mediator)
        {
            return await mediator.Send(command);
        }
    }
}
