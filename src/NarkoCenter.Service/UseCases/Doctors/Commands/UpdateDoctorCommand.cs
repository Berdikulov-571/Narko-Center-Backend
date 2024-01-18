using MediatR;
using NarkoCenter.Domain.Dtos.Doctors;

namespace NarkoCenter.Service.UseCases.Doctors.Commands
{
    public class UpdateDoctorCommand : DoctorUpdateDto, IRequest<int>
    {

    }
}