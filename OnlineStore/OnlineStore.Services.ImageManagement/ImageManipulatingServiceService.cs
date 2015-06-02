﻿namespace OnlineStore.Services.ImageManagement
{
    using System;
    using System.IO;

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
    }
}