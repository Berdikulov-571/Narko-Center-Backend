using MediatR;
using NarkoCenter.Domain.Dtos.Admins;

namespace NarkoCenter.Service.UseCases.Admins.Commands
{
    public class CreateAdminCommand : CreateAdminDto, IRequest<int>
    {

    }
}