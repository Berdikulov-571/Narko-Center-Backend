using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Doctors;
using NarkoCenter.Domain.Exceptions.Doctor;
using NarkoCenter.Domain.Exceptions.Images;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.Doctors.Commands;

namespace NarkoCenter.Service.UseCases.Doctors.Handlers
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFileService _fileService;

        public DeleteDoctorCommandHandler(IApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<int> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            Doctor? doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorId == request.DoctorId, cancellationToken);

            if (doctor == null)
                throw new DoctorNotFound();

            try
            {
                await _fileService.DeletFileAsync(doctor.ImagePath);
            }
            catch (Exception ex)
            {
                throw new ImageNotFound();
            }

            _context.Doctors.Remove(doctor);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}