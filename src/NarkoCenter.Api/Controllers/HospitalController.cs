using MediatR;
using Microsoft.AspNetCore.Mvc;
using NarkoCenter.Domain.Entities.Companies;
using NarkoCenter.Service.UseCases.Companies.Commands;
using NarkoCenter.Service.UseCases.Companies.Queries;

namespace NarkoCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HospitalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HospitalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateHospitalCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Hospital>? response = await _mediator.Send(new GetAllHospitalQuery());

            return Ok(response);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UpdateHospitalCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int HospitalId)
        {
            Hospital response = await _mediator.Send(new GetHospitalByIdQuery() { HospitalId = HospitalId});

            return Ok(response);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int HospitalId)
        {
            int response = await _mediator.Send(new DeleteHospitalCommand() { HospitalId = HospitalId});

            return Ok(response);
        }
    }
}