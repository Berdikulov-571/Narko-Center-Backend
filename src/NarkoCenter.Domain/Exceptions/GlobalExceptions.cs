using System.Net;

namespace NarkoCenter.Domain.Exceptions
{
    public class GlobalExceptions : Exception
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
        public string TitleMessage { get; set; } = default!;
    }
}