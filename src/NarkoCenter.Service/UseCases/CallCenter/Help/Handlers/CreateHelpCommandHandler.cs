using MediatR;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.CallCenter.Help.Commands;

namespace NarkoCenter.Service.UseCases.CallCenter.Help.Handlers
{
    public class CreateHelpCommandHandler : IRequestHandler<CreateHelpCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateHelpCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateHelpCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.CallCenter.Help help = new Domain.Entities.CallCenter.Help()
            {
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                WhatToTreatFor = request.WhatToTreatFor,
                WhoNeedsHelp = request.WhoNeedsHelp,
                WhereToPickUp = request.WhereToPickUp
            };

            await _context.Helps.AddAsync(help, cancellationToken);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}