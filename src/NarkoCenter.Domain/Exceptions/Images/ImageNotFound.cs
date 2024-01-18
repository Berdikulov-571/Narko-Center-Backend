namespace NarkoCenter.Domain.Exceptions.Images
{
    public class ImageNotFound : GlobalExceptions
    {
        public ImageNotFound()
        {
            TitleMessage = "Image Not Found!";
        }
    }
}