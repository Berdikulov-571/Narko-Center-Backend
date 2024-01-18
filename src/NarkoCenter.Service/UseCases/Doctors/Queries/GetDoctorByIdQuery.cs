using MediatR;
using NarkoCenter.Domain.Entities.Doctors;

namespace NarkoCenter.Service.UseCases.Doctors.Queries
{
    public class GetDoctorByIdQuery : IRequest<Doctor>
    {
        public int DoctorId { get; set; }
    }
}
