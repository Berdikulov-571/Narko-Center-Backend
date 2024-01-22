using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Admins;
using NarkoCenter.Domain.Exceptions.Admins;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Admins.Commands;

namespace NarkoCenter.Service.UseCases.Admins.Handlers
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAdminCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            Admin? admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == request.AdminId, cancellationToken);

            if (admin == null)
                throw new AdminNotFound();

            _context.Admins.Remove(admin);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}