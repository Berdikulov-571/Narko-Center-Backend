using MediatR;
using NarkoCenter.Domain.Entities.CallCenter;

namespace NarkoCenter.Service.UseCases.CallCenter.AnswerAndQuestions.Queries
{
    public class GetAnswerAndQuestionByIdQuery : IRequest<AnswerAndQuestions>
    {
        public int AnswerAndQuestionId { get; set; }
    }
}