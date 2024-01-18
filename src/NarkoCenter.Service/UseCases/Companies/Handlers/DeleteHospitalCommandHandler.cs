using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Companies;
using NarkoCenter.Domain.Exceptions.Hospital;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.Abstractions.File;
using NarkoCenter.Service.UseCases.Companies.Commands;

namespace NarkoCenter.Service.UseCases.Companies.Handlers
{
    public class DeleteHospitalCommandHandler : IRequestHandler<DeleteHospitalCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteHospitalCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteHospitalCommand request, CancellationToken cancellationToken)
        {
            Hospital? hospital = await _context.Hospitals.FirstOrDefaultAsync(x => x.HospitalId == request.HospitalId,cancellationToken);

            if (hospital == null)
                throw new HospitalNotFound();

            _context.Hospitals.Remove(hospital);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}