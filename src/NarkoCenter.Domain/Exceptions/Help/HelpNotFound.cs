namespace NarkoCenter.Domain.Exceptions.Help
{
    public class HelpNotFound : GlobalExceptions
    {
        public HelpNotFound()
        {
            TitleMessage = "Help Not Found!";
        }
    }
}