namespace NarkoCenter.Domain.Exceptions.Admins
{
    public class AdminNotFound : GlobalExceptions
    {
        public AdminNotFound()
        {
            TitleMessage = "Admin Not Found!";
        }
    }
}