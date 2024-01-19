using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.HospitalNews;
using NarkoCenter.Domain.Exceptions.News;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.HospitalNews.Queries;

namespace NarkoCenter.Service.UseCases.HospitalNews.Handlers
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, News>
    {
        private readonly IApplicationDbContext _context;

        public GetNewsByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            News? news = await _context.News.FirstOrDefaultAsync(x => x.NewsId == request.NewsId, cancellationToken);

            if (news == null)
                throw new NewsNotFound();

            return news;
        }
    }
}