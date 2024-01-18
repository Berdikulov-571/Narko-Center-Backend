namespace NarkoCenter.Domain.Exceptions.PhoneNumber
{
    public class PhoneNumberAlreayExists : GlobalExceptions
    {
        public PhoneNumberAlreayExists()
        {
            TitleMessage = "Phone Number Already Exists!";
        }
    }
}
