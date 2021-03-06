﻿namespace OnlineStore.Services.ValidationService.Contracts
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;

    using OnlineStore.Services.Common.Contracts;

    public interface IImageValidationService : IService
    {
        void ValidateProductPictures(IEnumerable<HttpPostedFileBase> pictures, Controller controller);
    }
}
