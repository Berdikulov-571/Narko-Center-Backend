using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Documents;
using NarkoCenter.Domain.Exceptions.Documents;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Documents.Queries;

namespace NarkoCenter.Service.UseCases.Documents.Handlers
{
    public class GetAllDocumentQueryHandler : IRequestHandler<GetAllDocumentQuery, IEnumerable<Document>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllDocumentQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Document>> Handle(GetAllDocumentQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Document> documents = await _context.Documents.ToListAsync(cancellationToken);

            if (documents.Count() == 0)
                throw new DocumentNotFound();
            return documents;
        }
    }
}