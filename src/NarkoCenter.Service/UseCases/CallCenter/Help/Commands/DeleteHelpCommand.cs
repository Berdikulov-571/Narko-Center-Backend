using MediatR;

namespace NarkoCenter.Service.UseCases.CallCenter.Help.Commands
{
    public class DeleteHelpCommand : IRequest<int>
    {
        public int HelpId { get; set; }
    }
}