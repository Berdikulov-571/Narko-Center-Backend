using MediatR;
using NarkoCenter.Domain.Dtos.Services;

namespace NarkoCenter.Service.UseCases.Services.Commands
{
    public class UpdateServiceCommand : ServiceUpdateDto, IRequest<int>
    {

    }
}