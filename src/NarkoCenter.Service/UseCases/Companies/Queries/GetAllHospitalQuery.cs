using MediatR;
using NarkoCenter.Domain.Entities.Companies;

namespace NarkoCenter.Service.UseCases.Companies.Queries
{
    public class GetAllHospitalQuery : IRequest<IEnumerable<Hospital>>
    {

    }
}