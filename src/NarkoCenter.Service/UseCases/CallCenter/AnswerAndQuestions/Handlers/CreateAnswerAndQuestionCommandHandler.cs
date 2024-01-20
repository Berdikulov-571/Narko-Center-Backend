using MediatR;
using NarkoCenter.Domain.Entities.CallCenter;
using NarkoCenter.Service.Abstractions.DataAccess;
using NarkoCenter.Service.UseCases.CallCenter.AnswerAndQuestions.Commands;

namespace NarkoCenter.Service.UseCases.CallCenter.AnswerAndQuestions.Handlers
{
    public class CreateAnswerAndQuestionCommandHandler : IRequestHandler<CreateAnswerAndQuestionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAnswerAndQuestionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateAnswerAndQuestionCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.CallCenter.AnswerAndQuestions answerAndQuestions = new Domain.Entities.CallCenter.AnswerAndQuestions()
            {
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                CreatedAt = DateTime.UtcNow,
            };

            await _context.AnswerAndQuestions.AddAsync(answerAndQuestions, cancellationToken);
            int response = await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}