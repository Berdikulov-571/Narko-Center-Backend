using MediatR;
using NarkoCenter.Domain.Entities.Services;
using NarkoCenter.Domain.Entities.Users;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Security;
using NarkoCenter.Service.UseCases.Users.Commands;
using NarkoCenter.TelegramBot;

namespace NarkoCenter.Service.UseCases.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User()
            {
                Email = request.Email,
                FullName = request.FullName,
                PasswordHash = PasswordHash.ComputeSHA512HashFromString(request.Password),
            };

            await _context.Users.AddAsync(user, cancellationToken);
            int response = await _context.SaveChangesAsync(cancellationToken);

            AfterMessage ms = new AfterMessage();
            await ms.Added(user);

            return response;
        }
    }
}