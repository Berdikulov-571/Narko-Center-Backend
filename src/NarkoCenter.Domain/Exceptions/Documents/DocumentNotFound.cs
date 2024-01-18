namespace NarkoCenter.Domain.Exceptions.Documents
{
    public class DocumentNotFound : GlobalExceptions
    {
        public DocumentNotFound()
        {
            TitleMessage = "Document Not Found!";
        }
    }
}