﻿namespace OnlineStore.Services.ImageManagement.Contracts
{
    using OnlineStore.Services.Common.Contracts;

    public interface IImageManipulatingService : IService
    {
        void ResizeAndSave(byte[] image, int? width, int? height, string mode, string directory);

        string GetProductImageDirectory(int id);

        void SaveThumbnailImage(byte[] image, string directory);

        void SavePreviewImage(byte[] image, string directory);

        void SaveFullSizeImage(byte[] image, string directory);
    }
}