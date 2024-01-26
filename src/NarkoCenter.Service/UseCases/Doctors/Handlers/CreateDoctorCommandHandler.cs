using MediatR;
using NarkoCenter.Domain.Entities.Doctors;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.Doctors.Commands;
using NarkoCenter.TelegramBot;

namespace NarkoCenter.Service.UseCases.Doctors.Handlers
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public CreateDoctorCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            Doctor doctor = new Doctor()
            {
                BirthDate = request.BirthDate,
                DoctorCategory = request.DoctorCategory,
                Experience = request.Experience,
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName,
                ImagePath = await _fileService.UploadImageAsync(request.Image)
            };

            await _context.Doctors.AddAsync(doctor);
            int response = await _context.SaveChangesAsync(cancellationToken);

            AfterMessage ms = new AfterMessage();
            await ms.Added(doctor);

            return response;
        }
    }
}