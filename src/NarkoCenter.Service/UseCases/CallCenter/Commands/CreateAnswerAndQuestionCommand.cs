using MediatR;
using NarkoCenter.Domain.Dtos.CallCenter;

namespace NarkoCenter.Service.UseCases.CallCenter.Commands
{
    public class CreateAnswerAndQuestionCommand : AnswerAndQuestionsCreateDto, IRequest<int>
    {

    }
}