﻿namespace OnlineStore.Services.ImageManagement.Contracts
{
    using System.IO;

    using OnlineStore.Services.Common;

    public interface IImageResizerService : IService
    {
        void Resize(Stream image, int width, int height, string format, string mode);
    }
}
