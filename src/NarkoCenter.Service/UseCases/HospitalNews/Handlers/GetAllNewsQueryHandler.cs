using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.HospitalNews;
using NarkoCenter.Domain.Exceptions.News;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.HospitalNews.Queries;

namespace NarkoCenter.Service.UseCases.HospitalNews.Handlers
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<News>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllNewsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<News>? news = await _context.News.ToListAsync(cancellationToken);

            if (news.Count() == 0)
                throw new NewsNotFound();
            return news;
        }
    }
}