using MediatR;

namespace NarkoCenter.Service.UseCases.CallCenter.Help.Queries
{
    public class GetAllHelpQuery : IRequest<IEnumerable<Domain.Entities.CallCenter.Help>>
    {

    }
}