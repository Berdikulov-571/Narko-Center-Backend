namespace NarkoCenter.Domain.Dtos.Doctors
{
    public class DoctorCreateDto
    {
        public string FullName { get; set; }
        public string DoctorCategory { get; set; }
        public int Experience { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; }
    }
}