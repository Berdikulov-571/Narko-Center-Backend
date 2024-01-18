namespace NarkoCenter.Domain.Exceptions.Hospital
{
    public class HospitalNotFound : GlobalExceptions
    {
        public HospitalNotFound()
        {
            TitleMessage = "Hospital Not Found!";
        }
    }
}