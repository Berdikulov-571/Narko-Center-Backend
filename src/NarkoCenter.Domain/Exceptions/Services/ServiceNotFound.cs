namespace NarkoCenter.Domain.Exceptions.Services
{
    public class ServiceNotFound : GlobalExceptions
    {
        public ServiceNotFound()
        {
            TitleMessage = "Service Not Found!";
        }
    }
}