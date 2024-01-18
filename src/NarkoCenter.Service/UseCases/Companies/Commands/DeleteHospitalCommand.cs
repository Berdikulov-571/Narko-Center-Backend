using MediatR;

namespace NarkoCenter.Service.UseCases.Companies.Commands
{
    public class DeleteHospitalCommand : IRequest<int>
    {
        public int HospitalId { get; set; }
    }
}