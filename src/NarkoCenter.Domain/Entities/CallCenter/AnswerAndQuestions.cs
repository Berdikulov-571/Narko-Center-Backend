using System.ComponentModel.DataAnnotations;

namespace NarkoCenter.Domain.Entities.CallCenter
{
    public class AnswerAndQuestions
    {
        [Key]
        public int QuestionId { get; set; }
        public string FullName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}