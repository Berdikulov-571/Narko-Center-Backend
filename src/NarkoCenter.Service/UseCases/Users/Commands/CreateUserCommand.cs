using MediatR;
using NarkoCenter.Domain.Dtos.Users;

namespace NarkoCenter.Service.UseCases.Users.Commands
{
    public class CreateUserCommand : UserCreateDto, IRequest<int>
    {

    }
}