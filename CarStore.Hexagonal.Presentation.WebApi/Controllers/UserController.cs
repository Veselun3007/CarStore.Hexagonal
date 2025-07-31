using CarStore.Hexagonal.Application.Features.Users.Commands.AddUser;
using CarStore.Hexagonal.Application.Features.Users.Commands.DeleteUser;
using CarStore.Hexagonal.Application.Features.Users.Commands.UpdateUser;
using CarStore.Hexagonal.Application.Features.Users.Queries.GetAllUser;
using CarStore.Hexagonal.Application.Features.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Hexagonal.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUserQuery(), new CancellationToken());
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            var result = await _mediator.Send(new GetUserByIdQuery { UserId = userId }, new CancellationToken());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand request)
        {
            var result = await _mediator.Send(request, new CancellationToken());
            return Ok(result);
        }
    }
}
