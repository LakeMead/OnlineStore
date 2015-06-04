namespace OnlineStore.Services.ImageManagement
{
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;

    using ImageResizer;

    using OnlineStore.Common.Constants;
    using OnlineStore.Services.ImageManagement.Contracts;

    public class ImageManipulatingServiceService : IImageManipulatingService
    {
        public void ResizeAndSave(byte[] image, int? width, int? height, string mode, string directory)
        {
            using (var stream = new MemoryStream(image))
            {
                  var resizedImage = new ImageJob(
                    stream,
                    directory,
                    new Instructions("width=" + width + ";height=" + height + ";mode=" + mode))
                {
                    CreateParentDirectory = true
                };

                resizedImage.Build();
            }
        }

        public Stream Resize(Stream image, int? width, int? height, string mode)
        {
            var destinationStream = new MemoryStream();
            var resizedImage = new ImageJob(
                    image,
                    destinationStream,
                    new Instructions("width=" + width + ";height=" + height + ";mode=" + mode))
            {
                CreateParentDirectory = true
            };

            resizedImage.Build();

            return destinationStream;
        }

        public string GetProductImageDirectory(int id)
        {
            var parrentDirectory = (id % 1000).ToString();

            var productImagesDirectory = id.ToString();

            var path = ConfigurationsConstants.BaseProcutsImagesDirectory + parrentDirectory + "/" + productImagesDirectory + "/";

            return path;
        }

        public void SaveThumbnailImage(byte[] image, string directory)
        {
            this.ResizeAndSave(image, ConfigurationsConstants.ProductThumbnailImageWidth, ConfigurationsConstants.ProductThumbnailImageHeight, "crop", directory);
        }

        public void SavePreviewImage(byte[] image, string directory)
        {
            this.ResizeAndSave(image, ConfigurationsConstants.ProductPreviewImageWidth, ConfigurationsConstants.ProductPreviewImageHeight, "max", directory);
        }

        public void SaveFullSizeImage(byte[] image, string directory)
        {
            this.ResizeAndSave(image, null, null, "max", directory);
        }

        public string GetFirstThumbnailPath(string productDirectoryPath)
        {
            var path = HostingEnvironment.MapPath(productDirectoryPath);
            var productImagePath = Directory.EnumerateFiles(path).FirstOrDefault(file => file.Contains("thumbnail"));

            var productImageName = productImagePath != null ? productImagePath.Replace(path, string.Empty) : "default";

            return productImageName;
        }
    }
}
