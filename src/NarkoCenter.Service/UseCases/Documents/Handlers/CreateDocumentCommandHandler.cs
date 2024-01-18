using MediatR;
using NarkoCenter.Domain.Entities.Documents;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.Documents.Commands;

namespace NarkoCenter.Service.UseCases.Documents.Handlers
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public CreateDocumentCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            Document document = new Document()
            {
                CreatedAt = DateTime.UtcNow,
                DocumentPath = await _fileService.UploadImageAsync(request.DocumentPath),
                DocumentType = request.DocumentType,
            };

            await _context.Documents.AddAsync(document, cancellationToken);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}