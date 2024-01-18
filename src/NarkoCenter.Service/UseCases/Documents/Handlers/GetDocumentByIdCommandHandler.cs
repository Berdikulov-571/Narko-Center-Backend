using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Documents;
using NarkoCenter.Domain.Exceptions.Documents;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Documents.Queries;

namespace NarkoCenter.Service.UseCases.Documents.Handlers
{
    public class GetDocumentByIdCommandHandler : IRequestHandler<GetDocumentByIdQuery, Document>
    {
        private readonly IApplicationDbContext _context;

        public GetDocumentByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Document> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            Document? document = await _context.Documents.FirstOrDefaultAsync(x => x.DocumentId == request.DocumentId, cancellationToken);

            if (document == null)
                throw new DocumentNotFound();

            return document;
        }
    }
}