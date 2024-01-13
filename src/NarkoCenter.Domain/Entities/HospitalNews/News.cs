namespace NarkoCenter.Domain.Entities.HospitalNews
{
    public class News
    {
        public int NewsId { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}