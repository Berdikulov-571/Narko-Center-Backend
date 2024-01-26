using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.Services.Commands;
using NarkoCenter.TelegramBot;

namespace NarkoCenter.Service.UseCases.Services.Handlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public UpdateServiceCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Services.Service service = await _context.Services.FirstOrDefaultAsync(x => x.ServiceId == request.ServiceId, cancellationToken);

            service.DoctorId = request.DoctorId;
            service.HowManyPeopleThisRoom = request.HowManyPeopleThisRoom;
            service.PriceADay = request.PriceADay;
            service.CreatedAt = DateTime.UtcNow;
            service.ServiceName = request.ServiceName;
            service.UpdatedAt = DateTime.UtcNow;

            if (request.IconPath != null)
            {
                await _fileService.DeletFileAsync(service.IconPath);
                service.IconPath = await _fileService.UploadImageAsync(request.IconPath);
            }

            _context.Services.Update(service);
            int response = await _context.SaveChangesAsync(cancellationToken);

            AfterMessage ms = new AfterMessage();
            await ms.Updated(service);

            return response;
        }
    }
}