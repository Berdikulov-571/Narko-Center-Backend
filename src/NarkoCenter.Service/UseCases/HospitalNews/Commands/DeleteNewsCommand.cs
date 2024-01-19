using MediatR;

namespace NarkoCenter.Service.UseCases.HospitalNews.Commands
{
    public class DeleteNewsCommand : IRequest<int>
    {
        public int NewsId { get; set; }
    }
}