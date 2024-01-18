using Microsoft.AspNetCore.Http;

namespace NarkoCenter.Domain.Dtos.Doctors
{
    public class DoctorUpdateDto
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string DoctorCategory { get; set; }
        public int Experience { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public IFormFile? Image { get; set; }
    }
}
