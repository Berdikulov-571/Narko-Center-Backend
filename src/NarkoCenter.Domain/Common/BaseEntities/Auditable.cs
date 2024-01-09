namespace NarkoCenter.Domain.Common.BaseEntities
{
    public class Auditable
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}