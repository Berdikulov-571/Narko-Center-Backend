namespace NarkoCenter.Domain.Exceptions.Users
{
    public class UserNotFound : GlobalExceptions
    {
        public UserNotFound()
        {
            TitleMessage = "User Not Found!";
        }
    }
}