namespace NarkoCenter.Domain.Exceptions.NotValid
{
    public class FileNotValid : GlobalExceptions
    {
        public FileNotValid()
        {
            TitleMessage = "File Not Valid!";
        }
    }
}