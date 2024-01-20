using MediatR;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.Services.Commands;

namespace NarkoCenter.Service.UseCases.Services.Handlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public CreateServiceCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Services.Service service = new Domain.Entities.Services.Service()
            {
                DoctorId = request.DoctorId,
                HowManyPeopleThisRoom = request.HowManyPeopleThisRoom,
                PriceADay = request.PriceADay,
                IconPath = await _fileService.UploadImageAsync(request.IconPath),
                CreatedAt = DateTime.UtcNow,
                ServiceName = request.ServiceName,
            };

            await _context.Services.AddAsync(service);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}