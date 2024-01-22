using MediatR;

namespace NarkoCenter.Service.UseCases.Admins.Commands
{
    public class DeleteAdminCommand : IRequest<int>
    {
        public int AdminId { get; set; }
    }
}