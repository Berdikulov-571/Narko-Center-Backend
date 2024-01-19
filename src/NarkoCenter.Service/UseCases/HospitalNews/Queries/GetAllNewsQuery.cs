using MediatR;
using NarkoCenter.Domain.Entities.HospitalNews;

namespace NarkoCenter.Service.UseCases.HospitalNews.Queries
{
    public class GetAllNewsQuery : IRequest<IEnumerable<News>>
    {
    }
}