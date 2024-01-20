using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Exceptions.Help;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.CallCenter.Help.Queries;

namespace NarkoCenter.Service.UseCases.CallCenter.Help.Handlers
{
    public class GetAllHelpsQueryHandler : IRequestHandler<GetAllHelpQuery, IEnumerable<Domain.Entities.CallCenter.Help>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllHelpsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.CallCenter.Help>> Handle(GetAllHelpQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.CallCenter.Help> helps = await _context.Helps.AsNoTracking().ToListAsync(cancellationToken);

            return helps;
        }
    }
}