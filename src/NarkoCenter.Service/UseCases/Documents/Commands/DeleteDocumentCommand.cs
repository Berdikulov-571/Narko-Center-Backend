using MediatR;

namespace NarkoCenter.Service.UseCases.Documents.Commands
{
    public class DeleteDocumentCommand : IRequest<int>
    {
        public int DocumentId { get; set; }
    }
}