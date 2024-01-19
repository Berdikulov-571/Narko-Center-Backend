namespace NarkoCenter.Domain.Exceptions.News
{
    public class NewsNotFound : GlobalExceptions
    {
        public NewsNotFound()
        {
            TitleMessage = "News Not Found!";
        }
    }
}