using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Documents;
using NarkoCenter.Domain.Exceptions.Documents;
using NarkoCenter.Domain.Exceptions.Images;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.Documents.Commands;

namespace NarkoCenter.Service.UseCases.Documents.Handlers
{
    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public DeleteDocumentCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            Document? document = await _context.Documents.FirstOrDefaultAsync(x => x.DocumentId == request.DocumentId, cancellationToken);

            if (document == null)
                throw new DocumentNotFound();

            try
            {
                await _fileService.DeletFileAsync(document.DocumentPath);
            }
            catch
            {
                throw new ImageNotFound();
            }

            _context.Documents.Remove(document);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}