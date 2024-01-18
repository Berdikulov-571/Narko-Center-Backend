using MediatR;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.CallCenter.Commands;

namespace NarkoCenter.Service.UseCases.CallCenter.Handlers
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
            _context.AnswerAndQuestions.RemoveRange();
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}