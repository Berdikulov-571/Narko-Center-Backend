using MediatR;
using NarkoCenter.Domain.Entities.Services;

namespace NarkoCenter.Service.UseCases.Services.Queries
{
    public class GetAllServiceQuery : IRequest<IEnumerable<Domain.Entities.Services.Service>>
    {

    }
}