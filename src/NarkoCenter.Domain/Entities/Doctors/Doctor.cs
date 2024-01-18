namespace NarkoCenter.Domain.Entities.Doctors
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string DoctorCategory { get; set; }
        public int Experience { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public DateTime BirthDate { get; set; }
    }
}