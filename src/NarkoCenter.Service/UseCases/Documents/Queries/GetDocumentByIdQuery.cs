using MediatR;
using NarkoCenter.Domain.Entities.Documents;

namespace NarkoCenter.Service.UseCases.Documents.Queries
{
    public class GetDocumentByIdQuery : IRequest<Document>
    {
        public int DocumentId { get; set; }
    }
}