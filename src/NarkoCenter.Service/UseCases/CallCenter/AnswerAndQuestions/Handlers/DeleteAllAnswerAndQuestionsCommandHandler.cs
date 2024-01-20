using MediatR;
using Microsoft.EntityFrameworkCore;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.CallCenter.AnswerAndQuestions.Commands;

namespace NarkoCenter.Service.UseCases.CallCenter.AnswerAndQuestions.Handlers
{
    public class DeleteAllAnswerAndQuestionsCommandHandler : IRequestHandler<DeleteAllAnswerAndQuestions, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAllAnswerAndQuestionsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteAllAnswerAndQuestions request, CancellationToken cancellationToken)
        {
            _context.AnswerAndQuestions.RemoveRange(await _context.AnswerAndQuestions.ToListAsync(cancellationToken));
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}