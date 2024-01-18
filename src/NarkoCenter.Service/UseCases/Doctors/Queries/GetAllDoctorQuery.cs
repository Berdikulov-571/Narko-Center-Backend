using MediatR;
using NarkoCenter.Domain.Entities.Doctors;

namespace NarkoCenter.Service.UseCases.Doctors.Queries
{
    public class GetAllDoctorQuery : IRequest<IEnumerable<Doctor>>
    {

    }
}