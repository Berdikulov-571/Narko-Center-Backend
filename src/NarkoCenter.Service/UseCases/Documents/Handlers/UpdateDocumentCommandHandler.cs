using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Documents;
using NarkoCenter.Domain.Exceptions.Documents;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.Documents.Commands;

namespace NarkoCenter.Service.UseCases.Documents.Handlers
{
    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public UpdateDocumentCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            Document? document = await _context.Documents.FirstOrDefaultAsync(x => x.DocumentId == request.DocumentId, cancellationToken);

            if (document == null)
                throw new DocumentNotFound();

            document.DocumentType = request.DocumentType;
            document.UpdatedAt = DateTime.UtcNow;

            if (request.DocumentPath != null)
            {
                await _fileService.DeleteImageAsync(document.DocumentPath);
                document.DocumentPath = await _fileService.UploadImageAsync(request.DocumentPath);
            }

            _context.Documents.Update(document);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}