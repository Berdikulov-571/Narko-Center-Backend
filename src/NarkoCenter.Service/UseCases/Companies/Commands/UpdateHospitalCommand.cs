using MediatR;
using NarkoCenter.Domain.Dtos.Companies;

namespace NarkoCenter.Service.UseCases.Companies.Commands
{
    public class UpdateHospitalCommand : HospitalUpdateDto, IRequest<int>
    {

    }
}