using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.HospitalNews;
using NarkoCenter.Domain.Exceptions.News;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.HospitalNews.Commands;

namespace NarkoCenter.Service.UseCases.HospitalNews.Handlers
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public UpdateNewsCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            News? news = await _context.News.FirstOrDefaultAsync(x => x.NewsId == request.HospitalNewsId, cancellationToken);

            if (news == null)
                throw new NewsNotFound();

            news.Description = request.Description;

            if (request.ImagePath != null)
            {
                await _fileService.DeleteImageAsync(news.ImagePath);
                news.ImagePath = await _fileService.UploadImageAsync(request.ImagePath);
            }

            _context.News.Update(news);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}