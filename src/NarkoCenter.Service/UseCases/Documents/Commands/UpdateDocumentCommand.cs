using MediatR;
using NarkoCenter.Domain.Dtos.Documents;

namespace NarkoCenter.Service.UseCases.Documents.Commands
{
    public class UpdateDocumentCommand : DocumentUpdateDto, IRequest<int>
    {

    }
}