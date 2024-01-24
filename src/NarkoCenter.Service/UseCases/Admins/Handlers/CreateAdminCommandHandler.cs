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
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAdminCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            Admin checkAdmin = await _context.Admins.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (checkAdmin != null)
                throw new AdminAlreadyExists();

            Admin admin = new Admin()
            {
                Email = request.Email,
                FullName = request.FullName,
                PasswordHash = PasswordHash.ComputeSHA512HashFromString(request.Password),
                Role = request.Role
            };

            await _context.Admins.AddAsync(admin);
            int response = await _context.SaveChangesAsync(cancellationToken);
            AfterMessage ms = new AfterMessage();
            ms.Added(admin);

            return response;
        }
    }
}