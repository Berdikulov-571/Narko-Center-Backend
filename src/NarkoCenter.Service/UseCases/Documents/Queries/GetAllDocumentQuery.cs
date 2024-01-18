using MediatR;
using NarkoCenter.Domain.Entities.Documents;

namespace NarkoCenter.Service.UseCases.Documents.Queries
{
    public class GetAllDocumentQuery : IRequest<IEnumerable<Document>>
    {

    }
}