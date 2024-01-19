using MediatR;
using NarkoCenter.Domain.Entities.HospitalNews;

namespace NarkoCenter.Service.UseCases.HospitalNews.Queries
{
    public class GetNewsByIdQuery : IRequest<News>
    {
        public int NewsId { get; set; }
    }
}