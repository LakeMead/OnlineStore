namespace OnlineStore.Web.Areas.Administration_Products.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using OnlineStore.Common.Constants;
    using OnlineStore.Data;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;
    using OnlineStore.Web.Controllers;
    using OnlineStore.Web.Infrastructure.Attributes;
    using OnlineStore.Web.Models.ViewModels.AdministrationProducts;

    public class ProductsController : KendoGridAdministrationController
    {
        public ProductsController(IOnlineStoreData data, IShoppingCartProvider shoppingCartProvider)
            : base(data, shoppingCartProvider)
        {
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
    }
}