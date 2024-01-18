using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.CallCenter;
using NarkoCenter.Domain.Exceptions.AnswerAndQuestions;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.CallCenter.Queries;

namespace NarkoCenter.Service.UseCases.CallCenter.Handlers
{
    public class GetAnswerAndQuestionByIdQueryHandler : IRequestHandler<GetAnswerAndQuestionByIdQuery, AnswerAndQuestions>
    {
        private readonly IApplicationDbContext _context;

        public GetAnswerAndQuestionByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AnswerAndQuestions> Handle(GetAnswerAndQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            AnswerAndQuestions? answerAndQuestions = await _context.AnswerAndQuestions.FirstOrDefaultAsync(x => x.QuestionId == request.AnswerAndQuestionId);

            if (answerAndQuestions == null)
                throw new QuestionNotFound();
            return answerAndQuestions;
        }
    }
}