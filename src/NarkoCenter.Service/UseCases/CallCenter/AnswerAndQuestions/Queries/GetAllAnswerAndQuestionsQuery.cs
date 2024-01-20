using MediatR;
using NarkoCenter.Domain.Entities.CallCenter;

namespace NarkoCenter.Service.UseCases.CallCenter.AnswerAndQuestions.Queries
{
    public class GetAllAnswerAndQuestionsQuery : IRequest<IEnumerable<AnswerAndQuestions>>
    {

    }
}