using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.Companies;
using NarkoCenter.Domain.Exceptions.PhoneNumber;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.Companies.Commands;

namespace NarkoCenter.Service.UseCases.Companies.Handlers
{
    public class CreateHospitalCommandHandler : IRequestHandler<CreateHospitalCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateHospitalCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
        {
            Hospital? checkPhoneNumber = await _context.Hospitals.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken);

            if (checkPhoneNumber != null)
                throw new PhoneNumberAlreayExists();

            Hospital hospital = new Hospital()
            {
                FacebookUrl = request.FacebookUrl,
                HospitalName = request.HospitalName,
                WContaceUrl = request.WContaceUrl,
                OpenedYear = request.OpenedYear,
                InstagramUrl = request.InstagramUrl,
                CreatedAt = DateTime.UtcNow,
                Location = request.Location,
                PhoneNumber = request.PhoneNumber,
                TelegramUrl = request.TelegramUrl,
                WorkingTime = request.WorkingTime,
            };

            await _context.Hospitals.AddAsync(hospital, cancellationToken);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}