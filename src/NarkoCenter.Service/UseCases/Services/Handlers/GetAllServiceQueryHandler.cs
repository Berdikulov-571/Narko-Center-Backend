using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Exceptions.Services;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.Services.Queries;

namespace NarkoCenter.Service.UseCases.Services.Handlers
{
    public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQuery, IEnumerable<Domain.Entities.Services.Service>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public GetAllServiceQueryHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<IEnumerable<Domain.Entities.Services.Service>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Services.Service> services = await _context.Services.ToListAsync(cancellationToken);

            if (services.Count() == 0)
                throw new ServiceNotFound();

            return services;
        }
    }
}