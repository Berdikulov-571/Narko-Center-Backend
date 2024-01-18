using MediatR;
using NarkoCenter.Domain.Entities.Companies;

namespace NarkoCenter.Service.UseCases.Companies.Queries
{
    public class GetHospitalByIdQuery : IRequest<Hospital>
    {
        public int HospitalId { get; set; }
    }
}