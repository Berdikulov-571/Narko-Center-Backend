using MediatR;
using Microsoft.AspNetCore.Mvc;
using NarkoCenter.Domain.Entities.CallCenter;
using NarkoCenter.Service.UseCases.CallCenter.Help.Commands;
using NarkoCenter.Service.UseCases.CallCenter.Help.Queries;

namespace NarkoCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HelpController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HelpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateHelpCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllHelpQuery());

            return Ok(response);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int HelpId)
        {
            int response = await _mediator.Send(new DeleteHelpCommand() { HelpId = HelpId });

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int HelpId)
        {
            Help response = await _mediator.Send(new GetHelpByIdQuery() { HelpId = HelpId });

            return Ok(response);
        }
    }
}