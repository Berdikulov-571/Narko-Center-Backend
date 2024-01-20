using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Exceptions.Services;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Services.Queries;

namespace NarkoCenter.Service.UseCases.Services.Handlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Domain.Entities.Services.Service>
    {
        private readonly IApplicationDbContext _context;

        public GetServiceByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Services.Service> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Services.Service service = await _context.Services.FirstOrDefaultAsync(x => x.ServiceId == request.ServiceId, cancellationToken);

            if (service == null)
                throw new ServiceNotFound();

            return service;
        }
    }
}