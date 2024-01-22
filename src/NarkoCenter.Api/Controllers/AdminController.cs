using MediatR;
using Microsoft.AspNetCore.Mvc;
using NarkoCenter.Domain.Entities.Admins;
using NarkoCenter.Service.UseCases.Admins.Commands;
using NarkoCenter.Service.UseCases.Admins.Queries;

namespace NarkoCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateAdminCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllAdminQuery());

            return Ok(response);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateAdminCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int adminId)
        {
            int response = await _mediator.Send(new DeleteAdminCommand() { AdminId = adminId });

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int adminId)
        {
            Admin admin = await _mediator.Send(new GetAdminByIdQuery() { AdminId = adminId });

            return Ok(admin);
        }
    }
}