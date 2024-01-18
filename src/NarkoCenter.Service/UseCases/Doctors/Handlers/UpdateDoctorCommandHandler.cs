using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Doctors;
using NarkoCenter.Domain.Exceptions.Doctor;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.Doctors.Commands;

namespace NarkoCenter.Service.UseCases.Doctors.Handlers
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public UpdateDoctorCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            Doctor? doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorId == request.DoctorId, cancellationToken);

            if (doctor == null)
                throw new DoctorNotFound();

            doctor.BirthDate = request.BirthDate;
            doctor.DoctorCategory = request.DoctorCategory;
            doctor.Experience = request.Experience;
            doctor.PhoneNumber = request.PhoneNumber;
            doctor.FullName = request.FullName;
            
            if(request.Image != null)
            {
                await _fileService.DeletFileAsync(doctor.ImagePath);
                doctor.ImagePath = await _fileService.UploadImageAsync(request.Image);
            }

            _context.Doctors.Update(doctor);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}