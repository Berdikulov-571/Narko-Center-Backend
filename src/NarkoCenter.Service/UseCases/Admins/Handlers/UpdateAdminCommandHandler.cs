using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Admins;
using NarkoCenter.Domain.Exceptions.Admins;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Security;
using NarkoCenter.Service.UseCases.Admins.Commands;
using NarkoCenter.TelegramBot;

namespace NarkoCenter.Service.UseCases.Admins.Handlers
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAdminCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            Admin? admin = await _context.Admins.FirstOrDefaultAsync(x => x.AdminId == request.AdminId, cancellationToken);

            if (admin == null)
                throw new AdminNotFound();

            admin.FullName = request.FullName;
            admin.PasswordHash = PasswordHash.ComputeSHA512HashFromString(request.Password);
            admin.Role = request.Role;
            admin.Email = request.Email;

            _context.Admins.Update(admin);
            int reponse = await _context.SaveChangesAsync(cancellationToken);

            AfterMessage ms = new AfterMessage();
            await ms.Updated(admin);

            return reponse;
        }
    }
}