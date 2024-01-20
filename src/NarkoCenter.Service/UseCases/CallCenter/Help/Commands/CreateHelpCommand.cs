using MediatR;
using NarkoCenter.Domain.Dtos.CallCenter;

namespace NarkoCenter.Service.UseCases.CallCenter.Help.Commands
{
    public class CreateHelpCommand : HelpCreateDto, IRequest<int>
    {

    }
}