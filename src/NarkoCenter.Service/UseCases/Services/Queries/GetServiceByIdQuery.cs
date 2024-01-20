using MediatR;

namespace NarkoCenter.Service.UseCases.Services.Queries
{
    public class GetServiceByIdQuery : IRequest<Domain.Entities.Services.Service>
    {
        public int ServiceId { get; set; }
    }
}