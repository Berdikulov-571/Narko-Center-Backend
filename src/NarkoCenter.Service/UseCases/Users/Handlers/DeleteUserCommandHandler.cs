using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Users;
using NarkoCenter.Domain.Exceptions.Users;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Users.Commands;

namespace NarkoCenter.Service.UseCases.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken);

            if (user == null)
                throw new UserNotFound();

            _context.Users.Remove(user);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}