using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Companies;
using NarkoCenter.Domain.Exceptions.Hospital;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Companies.Queries;

namespace NarkoCenter.Service.UseCases.Companies.Handlers
{
    public class GetHospitalByIdQueryHandler : IRequestHandler<GetHospitalByIdQuery, Hospital>
    {
        private readonly IApplicationDbContext _context;

        public GetHospitalByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Hospital> Handle(GetHospitalByIdQuery request, CancellationToken cancellationToken)
        {
            Hospital? hospital = await _context.Hospitals.FirstOrDefaultAsync(x => x.HospitalId == request.HospitalId, cancellationToken);

            if (hospital == null)
                throw new HospitalNotFound();
            
            return hospital;
        }
    }
}