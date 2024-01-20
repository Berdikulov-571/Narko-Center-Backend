using MediatR;

namespace NarkoCenter.Service.UseCases.Users.Commands
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int UserId { get; set; }
    }
}