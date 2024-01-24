using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Exceptions.Services;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.Services.Commands;
using NarkoCenter.TelegramBot;

namespace NarkoCenter.Service.UseCases.Services.Handlers
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public DeleteServiceCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Services.Service? service = await _context.Services.FirstOrDefaultAsync(x => x.ServiceId == request.ServiceId, cancellationToken);

            if (service == null)
                throw new ServiceNotFound();

            try
            {
                await _fileService.DeleteImageAsync(service.IconPath);
            }
            catch
            {
                throw new ServiceNotFound();
            }

            _context.Services.Remove(service);
            int response = await _context.SaveChangesAsync(cancellationToken);

            AfterMessage ms = new AfterMessage();
            ms.Deleted(service);

            return response;
        }
    }
}