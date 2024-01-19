using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.HospitalNews;
using NarkoCenter.Domain.Exceptions.Images;
using NarkoCenter.Domain.Exceptions.News;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.HospitalNews.Commands;

namespace NarkoCenter.Service.UseCases.HospitalNews.Handlers
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public DeleteNewsCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            News? news = await _context.News.FirstOrDefaultAsync(x => x.NewsId == request.NewsId, cancellationToken);

            if (news == null)
                throw new NewsNotFound();

            try
            {
                await _fileService.DeleteImageAsync(news.ImagePath);
            }
            catch
            {
                throw new ImageNotFound();
            }

            _context.News.Remove(news);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}