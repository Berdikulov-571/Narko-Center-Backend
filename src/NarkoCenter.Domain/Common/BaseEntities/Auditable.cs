namespace NarkoCenter.Domain.Common.BaseEntities
{
    public class Auditable
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}