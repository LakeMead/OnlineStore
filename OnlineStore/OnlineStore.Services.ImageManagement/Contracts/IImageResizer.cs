namespace OnlineStore.Services.ImageManagement.Contracts
{
    using System.Web;

    using OnlineStore.Services.Common;

    public interface IImageResizer : IService
    {
        void ResizeImage();

        string GetUploadedFilePath(HttpPostedFileBase image, string mainFolder, string subFolder);
    }
}
