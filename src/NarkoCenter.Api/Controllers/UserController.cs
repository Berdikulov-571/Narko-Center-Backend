using MediatR;
using Microsoft.AspNetCore.Mvc;
using NarkoCenter.Service.UseCases.Users.Commands;
using NarkoCenter.Service.UseCases.Users.Queries;

namespace NarkoCenter.Api.Controllers
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

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateUserCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());

            return Ok(response);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateUserCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int userId)
        {
            int response = await _mediator.Send(new DeleteUserCommand() { UserId = userId });

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int userId)
        {
            var response = await _mediator.Send(new GetUserByIdQuery() { UserId = userId });

            return Ok(response);
        }
    }
}