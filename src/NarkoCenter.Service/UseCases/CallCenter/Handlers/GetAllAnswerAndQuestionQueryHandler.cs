using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.CallCenter;
using NarkoCenter.Domain.Exceptions.AnswerAndQuestions;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.CallCenter.Queries;

namespace NarkoCenter.Service.UseCases.CallCenter.Handlers
{
    public class GetAllAnswerAndQuestionQueryHandler : IRequestHandler<GetAllAnswerAndQuestionsQuery, IEnumerable<AnswerAndQuestions>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAnswerAndQuestionQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AnswerAndQuestions>> Handle(GetAllAnswerAndQuestionsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AnswerAndQuestions> response = await _context.AnswerAndQuestions.ToListAsync(cancellationToken);

            if (response == null)
                throw new QuestionNotFound();
            return response;
        }
    }
}