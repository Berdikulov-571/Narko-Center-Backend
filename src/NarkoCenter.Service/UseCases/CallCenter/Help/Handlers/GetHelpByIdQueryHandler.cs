using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Exceptions.Help;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.CallCenter.Help.Queries;

namespace NarkoCenter.Service.UseCases.CallCenter.Help.Handlers
{
    public class GetHelpByIdQueryHandler : IRequestHandler<GetHelpByIdQuery, Domain.Entities.CallCenter.Help>
    {
        private readonly IApplicationDbContext _context;

        public GetHelpByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.CallCenter.Help> Handle(GetHelpByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.CallCenter.Help? help = await _context.Helps.FirstOrDefaultAsync(x => x.HelpId == request.HelpId, cancellationToken);

            if (help == null)
                throw new HelpNotFound();

            return help;
        }
    }
}
