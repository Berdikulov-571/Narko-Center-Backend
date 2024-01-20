using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Users;
using NarkoCenter.Domain.Exceptions.Users;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Users.Queries;

namespace NarkoCenter.Service.UseCases.Users.Handlers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllUserQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await _context.Users.AsNoTracking().ToListAsync(cancellationToken);

            if (users.Count() == 0)
                throw new UserNotFound();

            return users;
        }
    }
}