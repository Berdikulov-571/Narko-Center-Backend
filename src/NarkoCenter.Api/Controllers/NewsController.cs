using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NarkoCenter.Service.UseCases.HospitalNews.Commands;
using NarkoCenter.Service.UseCases.HospitalNews.Queries;

namespace NarkoCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateNewsCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllNewsQuery());

            return Ok(response);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateNewsCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int newsId)
        {
            int response = await _mediator.Send(new DeleteNewsCommand() { NewsId = newsId });

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int newsId)
        {
            var response = await _mediator.Send(new GetNewsByIdQuery() { NewsId = newsId });

            return Ok(response);
        }
    }
}