namespace OnlineStore.Web.Areas.Administration_Products.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using OnlineStore.Common.Constants;
    using OnlineStore.Data;
    using OnlineStore.Data.Models;
    using OnlineStore.Services.ImageManagement.Contracts;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;
    using OnlineStore.Services.ValidationService.Contracts;
    using OnlineStore.Web.Controllers;
    using OnlineStore.Web.Infrastructure.Attributes;
    using OnlineStore.Web.Models.ViewModels.AdministrationProducts;
    using OnlineStore.Web.Models.ViewModels.AdministrationProducts.Products;

    public class ProductsController : KendoGridAdministrationController
    {
        private readonly IImageValidationService imageValidator;
        private readonly IImageManipulatingService imageManipulatingService;

        public ProductsController(
            IOnlineStoreData data,
            IShoppingCartProvider shoppingCartProvider,
            IImageValidationService imageValidator,
            IImageManipulatingService imageManipulatingService)
            : base(data, shoppingCartProvider)
        {
            this.imageValidator = imageValidator;
            this.imageManipulatingService = imageManipulatingService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [PopulateFromCache(CacheIds.ProductCategoriesDropDown)]
        public ActionResult Add()
        {
            return this.View(new ProductInputModel());
        }

        [HttpPost]
        [PopulateFromCache(CacheIds.ProductCategoriesDropDown)]
        public ActionResult Add(ProductInputModel inputModel)
        {
            this.imageValidator.ValidateProductPictures(inputModel.Images, this);

            if (this.ModelState.IsValid)
            {
                var entity = Mapper.Map<Product>(inputModel);

                this.Data.Products.Add(entity);

                this.Data.SaveChanges();

                this.UploadPictureToProductId(inputModel.Images, entity.Id);

                this.Data.SaveChanges();

                return this.RedirectToAction(c => c.Add());
            }

            inputModel.Images = null;
            return this.View(inputModel);
        }

        [HttpGet]
        public ActionResult AddImagesToProduct()
        {
            return this.View(new UpdateImagesInputModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImagesToProduct(UpdateImagesInputModel inputModel)
        {
            if (this.Data.Products.All().Any(p => p.Id == inputModel.ProductId))
            {
                this.imageValidator.ValidateProductPictures(inputModel.Images, this);

                if (this.ModelState.IsValid)
                {
                    this.UploadPictureToProductId(inputModel.Images, inputModel.ProductId);
                    return this.RedirectToAction(c => c.AddImagesToProduct());
                }
            }

            return this.View(inputModel);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ProductGridViewModel model)
        {
            if (model != null)
            {
                this.Data.Products.DeleteById(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Products.All().Project().To<ProductGridViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Products.GetById(id) as T;
        }

        private void UploadPictureToProductId(IEnumerable<HttpPostedFileBase> images, int id)
        {
            var productImagesCategory = this.imageManipulatingService.GetProductImageDirectory(id);

            foreach (var image in images)
            {
                var filename = image.FileName;

                using (var ms = new MemoryStream())
                {
                    image.InputStream.CopyTo(ms);
                    ms.Position = 0;
                    var byteArray = ms.ToArray();

                    this.imageManipulatingService.SaveThumbnailImage(byteArray, productImagesCategory + "thumbnail-" + filename);
                    this.imageManipulatingService.SavePreviewImage(byteArray, productImagesCategory + "preview-" + filename);
                    this.imageManipulatingService.SaveFullSizeImage(byteArray, productImagesCategory + "full-size-" + filename);
                }
            }
        }
    }
}