using MediatR;

namespace NarkoCenter.Service.UseCases.Services.Commands
{
    public class DeleteServiceCommand : IRequest<int>
    {
        public int ServiceId { get; set; }
    }
}