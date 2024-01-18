using MediatR;
using NarkoCenter.Domain.Dtos.Documents;

namespace NarkoCenter.Service.UseCases.Documents.Commands
{
    public class CreateDocumentCommand : DocumentCreateDto, IRequest<int>
    {

    }
}