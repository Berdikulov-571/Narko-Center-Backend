using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NarkoCenter.Service.UseCases.Services.Commands;
using NarkoCenter.Service.UseCases.Services.Queries;

namespace NarkoCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm]CreateServiceCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllServiceQuery());

            return Ok(response);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm]UpdateServiceCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int serviceId)
        {
            int response = await _mediator.Send(new DeleteServiceCommand() { ServiceId = serviceId });

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int serviceId)
        {
            var response = await _mediator.Send(new GetServiceByIdQuery() { ServiceId = serviceId });

            return Ok(response);
        }

    }
}