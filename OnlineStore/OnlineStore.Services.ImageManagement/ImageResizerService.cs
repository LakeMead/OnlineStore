namespace OnlineStore.Services.ImageManagement
{
    using System.IO;

    using ImageResizer;

    using OnlineStore.Services.ImageManagement.Contracts;

    public class ImageResizerServiceService : IImageResizerService
    {
        public void Resize(Stream image, int width, int height, string format, string mode)
        {
            var resizedImage = new ImageJob(
                    image,
                    "~/uploads/<guid>.<ext>",
                    new Instructions("width=" + width + ";height=" + height + ";format=" + format + ";mode=" + mode))
                {
                    CreateParentDirectory = true
                };

            resizedImage.Build();
        }
    }
}
