using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NarkoCenter.Domain.Entities.Doctors;
using NarkoCenter.Service.UseCases.Doctors.Commands;
using NarkoCenter.Service.UseCases.Doctors.Queries;

namespace NarkoCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateDoctorCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllDoctorQuery());

            return Ok(response);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateDoctorCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int DoctorId)
        {
            int response = await _mediator.Send(new DeleteDoctorCommand() { DoctorId = DoctorId });

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int DoctorId)
        {
            Doctor response = await _mediator.Send(new GetDoctorByIdQuery() { DoctorId = DoctorId });

            return Ok(response);
        }

    }
}
