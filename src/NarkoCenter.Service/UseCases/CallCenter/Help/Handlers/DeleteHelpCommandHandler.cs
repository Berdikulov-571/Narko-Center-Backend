using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Exceptions.Help;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.CallCenter.Help.Commands;

namespace NarkoCenter.Service.UseCases.CallCenter.Help.Handlers
{
    public class DeleteHelpCommandHandler : IRequestHandler<DeleteHelpCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteHelpCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteHelpCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.CallCenter.Help? help = await _context.Helps.FirstOrDefaultAsync(x => x.HelpId == request.HelpId,cancellationToken);

            if (help == null)
                throw new HelpNotFound();

            _context.Helps.Remove(help);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}