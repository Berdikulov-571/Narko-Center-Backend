using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Doctors;
using NarkoCenter.Domain.Exceptions.Doctor;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Doctors.Queries;

namespace NarkoCenter.Service.UseCases.Doctors.Handlers
{
    public class GetDoctosByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Doctor>
    {
        private readonly IApplicationDbContext _context;

        public GetDoctosByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            Doctor? doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorId == request.DoctorId,cancellationToken);

            if (doctor == null)
                throw new DoctorNotFound();
            return doctor;
        }
    }
}