using MediatR;
using NarkoCenter.Domain.Entities.Users;

namespace NarkoCenter.Service.UseCases.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {

    }
}