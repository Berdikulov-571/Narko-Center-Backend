using MediatR;
using NarkoCenter.Domain.Dtos.CallCenter;

namespace NarkoCenter.Service.UseCases.CallCenter.AnswerAndQuestions.Commands
{
    public class CreateAnswerAndQuestionCommand : AnswerAndQuestionsCreateDto, IRequest<int>
    {

    }
}