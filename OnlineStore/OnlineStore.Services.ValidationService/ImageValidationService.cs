namespace OnlineStore.Services.ValidationService
{
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    using OnlineStore.Common.Constants;
    using OnlineStore.Services.ValidationService.Contracts;

    public class ImageValidationService : IImageValidationService
    {
        public void ValidateProductPictures(IEnumerable<HttpPostedFileBase> pictures, Controller controller)
        {
            foreach (var picture in pictures)
            {
                if (picture != null)
                {
                    var extension = Path.GetExtension(picture.FileName);
                    if (extension == null || !ValidationConstants.AllowedPictureFormats.Contains(extension.ToLower()))
                    {
                        controller.ModelState.AddModelError("Picture", "Невалиден формат на снимката.");
                    }

                    if (picture.ContentLength > ValidationConstants.PictureMaxSize)
                    {
                        controller.ModelState.AddModelError("Picture", "Прекалено голяма снимка.");
                    }
                }
            }
        }
    }
}
