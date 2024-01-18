using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Companies;
using NarkoCenter.Domain.Exceptions.Hospital;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Companies.Queries;

namespace NarkoCenter.Service.UseCases.Companies.Handlers
{
    public class GetAllHospitalQueryHandler : IRequestHandler<GetAllHospitalQuery, IEnumerable<Hospital>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllHospitalQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hospital>> Handle(GetAllHospitalQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Hospital>? hospitals = await _context.Hospitals.ToListAsync(cancellationToken);

            if (hospitals == null)
                throw new HospitalNotFound();
            return hospitals;
        }
    }
}