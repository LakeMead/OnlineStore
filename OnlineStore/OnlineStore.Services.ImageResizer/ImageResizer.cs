namespace OnlineStore.Services.ImageResizer
{
    using System;
    using System.IO;
    using System.Web;

    using OnlineStore.Services.ImageResizer.Contracts;

    public class ImageResizer : IImageResizer
    {
        public void ResizeImage()
        {
           throw new NotImplementedException();
        }

        public string GetUploadedFilePath(HttpPostedFileBase file, string mainFolder, string subfolderName)
        {
            var fileExtension = this.GetFileExtension(file);
            var uniqueFileName = string.Format("{0}.{1}", Guid.NewGuid(), fileExtension);

            this.GetDirectoryByPathAndName(mainFolder, string.Format("~/{0}", mainFolder));
            this.GetDirectoryByPathAndName(subfolderName, string.Format("~/{0}/{1}", mainFolder, subfolderName));

            file.SaveAs(HttpContext.Current.Server.MapPath(string.Format("~/{0}/{1}/{2}", mainFolder, subfolderName, uniqueFileName)));

            return string.Format("/{0}/{1}/{2}", mainFolder, subfolderName, uniqueFileName);
        }

        private void GetDirectoryByPathAndName(string dirName, string pathPattern)
        {
            var dirExists = Directory.Exists(HttpContext.Current.Server.MapPath(dirName));
            if (!dirExists)
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(pathPattern));
            }
        }

        private string GetFileExtension(HttpPostedFileBase file)
        {
            var fileData = Path.GetFileName(file.FileName).Split(new char[] { '.' });
            var fileExtension = fileData[fileData.Length - 1];

            return fileExtension;
        }
    }
}
