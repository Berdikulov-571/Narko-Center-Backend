using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Companies;
using NarkoCenter.Domain.Exceptions.Hospital;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Companies.Commands;

namespace NarkoCenter.Service.UseCases.Companies.Handlers
{
    public class UpdateHospitalCommandHandler : IRequestHandler<UpdateHospitalCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateHospitalCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
        {
            Hospital? hospital = await _context.Hospitals.FirstOrDefaultAsync(x => x.HospitalId == request.HospitalId,cancellationToken);

            if (hospital == null)
                throw new HospitalNotFound();

            hospital.FacebookUrl = request.FacebookUrl;
            hospital.HospitalName = request.HospitalName;
            hospital.WContaceUrl = request.WContaceUrl;
            hospital.OpenedYear = request.OpenedYear;
            hospital.InstagramUrl = request.InstagramUrl;
            hospital.Location = request.Location;
            hospital.PhoneNumber = request.PhoneNumber;
            hospital.TelegramUrl = request.TelegramUrl;
            hospital.WorkingTime = request.WorkingTime;
            hospital.UpdatedAt = DateTime.UtcNow;

            _context.Hospitals.Update(hospital);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}