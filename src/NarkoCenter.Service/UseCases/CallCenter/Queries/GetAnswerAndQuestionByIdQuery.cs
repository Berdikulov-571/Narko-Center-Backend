using MediatR;
using NarkoCenter.Domain.Entities.CallCenter;

namespace NarkoCenter.Service.UseCases.CallCenter.Queries
{
    public class GetAnswerAndQuestionByIdQuery : IRequest<AnswerAndQuestions>
    {
        public int AnswerAndQuestionId { get; set; }
    }
}