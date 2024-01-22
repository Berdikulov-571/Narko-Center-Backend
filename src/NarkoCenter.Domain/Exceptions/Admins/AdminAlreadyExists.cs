namespace NarkoCenter.Domain.Exceptions.Admins
{
    public class AdminAlreadyExists : GlobalExceptions
    {
        public AdminAlreadyExists()
        {
            TitleMessage = "Admin Already Exists!";
        }
    }
}