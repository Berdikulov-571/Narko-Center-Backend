using MediatR;

namespace NarkoCenter.Service.UseCases.CallCenter.Help.Queries
{
    public class GetHelpByIdQuery : IRequest<Domain.Entities.CallCenter.Help>
    {
        public int HelpId { get; set; }
    }
}