namespace Autorization.Exceptions
{
    public class UserNotFound : Exception
    {
        public string TitleMessage { get; set; }
        public UserNotFound()
        {
            TitleMessage = "User Not Found!";
        }
    }
}