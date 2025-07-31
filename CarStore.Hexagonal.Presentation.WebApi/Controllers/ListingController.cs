using CarStore.Hexagonal.Application.Features.Listings.Commands.AddListing;
using CarStore.Hexagonal.Application.Features.Listings.Commands.CancelListing;
using CarStore.Hexagonal.Application.Features.Listings.Commands.DeleteListing;
using CarStore.Hexagonal.Application.Features.Listings.Commands.PostListing;
using CarStore.Hexagonal.Application.Features.Listings.Commands.ReopenListing;
using CarStore.Hexagonal.Application.Features.Listings.Commands.UpdateListing;
using CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.AcceptOffer;
using CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.AddOffer;
using CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.DeclineOffer;
using CarStore.Hexagonal.Application.Features.Listings.Offers.Commands.DeleteOffer;
using CarStore.Hexagonal.Application.Features.Listings.Queries.GetAllListing;
using CarStore.Hexagonal.Application.Features.Listings.Queries.GetListingById;
using CarStore.Hexagonal.Application.Features.Listings.TestDriveRequests.Commands.AddTestDriveRequest;
using CarStore.Hexagonal.Application.Features.Listings.TestDriveRequests.Commands.ApproveTestDrive;
using CarStore.Hexagonal.Application.Features.Listings.TestDriveRequests.Commands.DeleteTestDriveRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Hexagonal.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ListingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllListingQuery(), new CancellationToken());
            return Ok(result);
        }

        [HttpGet("{listingId}")]
        public async Task<IActionResult> GetById(string listingId)
        {
            var result = await _mediator.Send(new GetListingByIdQuery { ListingId = listingId }, new CancellationToken());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddListingCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateListingCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteListingCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Post([FromBody] PostListingCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Cancel([FromBody] CancelListingCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Reopen([FromBody] ReopenListingCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddOffer([FromBody] AddOfferCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptOffer([FromBody] AcceptOfferCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeclineOffer([FromBody] DeclineOfferCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOffer([FromBody] DeleteOfferCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RequestTestDrive([FromBody] AddTestDriveRequestCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveTestDrive([FromBody] ApproveTestDriveCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTestDrive([FromBody] DeleteTestDriveRequestCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }
    }
}
