using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Users;
using NarkoCenter.Domain.Exceptions.Users;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Security;
using NarkoCenter.Service.UseCases.Users.Commands;

namespace NarkoCenter.Service.UseCases.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken);

            if (user == null)
                throw new UserNotFound();

            user.Email = request.Email;
            user.FullName = request.FullName;
            user.PasswordHash = PasswordHash.ComputeSHA512HashFromString(request.Password);

            _context.Users.Update(user);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}