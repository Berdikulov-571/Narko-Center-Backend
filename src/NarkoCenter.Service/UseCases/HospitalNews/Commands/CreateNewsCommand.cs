using MediatR;
using NarkoCenter.Domain.Dtos.HospitalNews;

namespace NarkoCenter.Service.UseCases.HospitalNews.Commands
{
    public class CreateNewsCommand : HospitalNewsCreateDto, IRequest<int>
    {

    }
}