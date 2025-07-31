using CarStore.Hexagonal.Application.Features.Cars.Commands.AddCar;
using CarStore.Hexagonal.Application.Features.Cars.Commands.DeleteCar;
using CarStore.Hexagonal.Application.Features.Cars.Commands.UpdateCar;
using CarStore.Hexagonal.Application.Features.Cars.Queries.GetAllCar;
using CarStore.Hexagonal.Application.Features.Cars.Queries.GetCarById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Hexagonal.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCarQuery(), new CancellationToken());
            return Ok(result);
        }

        [HttpGet("{carId}")]
        public async Task<IActionResult> GetById(string carId)
        {
            var result = await _mediator.Send(new GetCarByIdQuery { CarId = carId }, new CancellationToken());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCarCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCarCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }
    }
}
