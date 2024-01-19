using MediatR;
using NarkoCenter.Domain.Entities.HospitalNews;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.HospitalNews.Commands;

namespace NarkoCenter.Service.UseCases.HospitalNews.Handlers
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public CreateNewsCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            News news = new News()
            {
                CreatedAt = DateTime.UtcNow,
                Description = request.Description,
                ImagePath = await _fileService.UploadImageAsync(request.ImagePath),
            };

            await _context.News.AddAsync(news);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}