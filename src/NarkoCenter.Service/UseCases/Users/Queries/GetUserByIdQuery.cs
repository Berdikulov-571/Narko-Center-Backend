using MediatR;
using NarkoCenter.Domain.Entities.Users;

namespace NarkoCenter.Service.UseCases.Users.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }
    }
}