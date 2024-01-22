using MediatR;
using NarkoCenter.Domain.Dtos.Admins;

namespace NarkoCenter.Service.UseCases.Admins.Commands
{
    public class UpdateAdminCommand : UpdateAdminDto, IRequest<int>
    {

    }
}