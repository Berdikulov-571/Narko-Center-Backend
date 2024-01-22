using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Admins;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Admins.Queries;

namespace NarkoCenter.Service.UseCases.Admins.Handlers
{
    public class GetAllAdminQueryHandler : IRequestHandler<GetAllAdminQuery, IEnumerable<Admin>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAdminQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Admin>> Handle(GetAllAdminQuery request, CancellationToken cancellationToken)
        {
            var admins = await _context.Admins.ToListAsync(cancellationToken);

            return admins;
        }
    }
}