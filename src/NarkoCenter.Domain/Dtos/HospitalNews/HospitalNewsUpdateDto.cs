using Microsoft.AspNetCore.Http;

namespace NarkoCenter.Domain.Dtos.HospitalNews
{
    public class HospitalNewsUpdateDto
    {
        public int HospitalNewsId { get; set; }
        public string Description { get; set; }
        public IFormFile? ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}