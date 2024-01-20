using MediatR;
using Microsoft.AspNetCore.Mvc;
using NarkoCenter.Service.UseCases.Documents.Commands;
using NarkoCenter.Service.UseCases.Documents.Queries;

namespace NarkoCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateDocumentCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllDocumentQuery());

            return Ok(response);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateDocumentCommand command)
        {
            int response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int documentId)
        {
            int response = await _mediator.Send(new DeleteDocumentCommand() { DocumentId = documentId });

            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int documentId)
        {
            var response = await _mediator.Send(new GetDocumentByIdQuery() { DocumentId = documentId });

            return Ok(response);
        }
    }
}
