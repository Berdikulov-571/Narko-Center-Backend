namespace NarkoCenter.Domain.Exceptions.AnswerAndQuestions
{
    public class QuestionNotFound : GlobalExceptions
    {
        public QuestionNotFound()
        {
            TitleMessage = "Question Not Found!";
        }
    }
}
