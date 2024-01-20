using MediatR;
using Microsoft.AspNetCore.Mvc;
using NarkoCenter.Domain.Entities.CallCenter;
using NarkoCenter.Service.UseCases.CallCenter.AnswerAndQuestions.Commands;
using NarkoCenter.Service.UseCases.CallCenter.AnswerAndQuestions.Queries;

namespace NarkoCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AnswerAndQuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswerAndQuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateAnswerAndQuestionCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<AnswerAndQuestions>? response = await _mediator.Send(new GetAllAnswerAndQuestionsQuery());

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int AnswerAndQuestionsId)
        {
            AnswerAndQuestions? response = await _mediator.Send(new GetAnswerAndQuestionByIdQuery() { AnswerAndQuestionId = AnswerAndQuestionsId });

            return Ok(response);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync()
        {
            int response = await _mediator.Send(new DeleteAllAnswerAndQuestions());

            return Ok(response);
        }
    }
}