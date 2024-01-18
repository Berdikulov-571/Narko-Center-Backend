using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Doctors;
using NarkoCenter.Domain.Exceptions.Doctor;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Doctors.Queries;

namespace NarkoCenter.Service.UseCases.Doctors.Handlers
{
    public class GetAllDoctorQueryHandler : IRequestHandler<GetAllDoctorQuery, IEnumerable<Doctor>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllDoctorQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Doctor> doctors = await _context.Doctors.ToListAsync(cancellationToken);

            if (doctors.Count() == 0)
                throw new DoctorNotFound();
            return doctors;
        }
    }
}