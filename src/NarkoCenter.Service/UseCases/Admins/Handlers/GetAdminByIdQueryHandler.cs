using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Admins;
using NarkoCenter.Domain.Exceptions.Admins;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Admins.Queries;

namespace NarkoCenter.Service.UseCases.Admins.Handlers
{
    public class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, Admin>
    {
        private readonly IApplicationDbContext _context;

        public GetAdminByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            Admin admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == request.AdminId,cancellationToken);

            if (admin == null)
                throw new AdminNotFound();

            return admin;
        }
    }
}