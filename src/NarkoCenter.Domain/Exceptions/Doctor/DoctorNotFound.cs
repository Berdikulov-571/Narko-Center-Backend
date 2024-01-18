namespace NarkoCenter.Domain.Exceptions.Doctor
{
    public class DoctorNotFound : GlobalExceptions
    {
        public DoctorNotFound()
        {
            TitleMessage = "Doctor Not Found!";
        }
    }
}