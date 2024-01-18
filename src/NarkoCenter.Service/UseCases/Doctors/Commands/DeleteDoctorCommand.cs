using MediatR;

namespace NarkoCenter.Service.UseCases.Doctors.Commands
{
    public class DeleteDoctorCommand : IRequest<int>
    {
        public int DoctorId { get; set; }
    }
}