namespace OnlineStore.Services.ImageManagement.Contracts
{
    using System.Web;

    using OnlineStore.Services.Common.Contracts;

    public interface IImageSaverService : IService
    {
        string GetUploadedFilePath(HttpPostedFileBase image, string mainFolder, string subFolder);
    }
}
