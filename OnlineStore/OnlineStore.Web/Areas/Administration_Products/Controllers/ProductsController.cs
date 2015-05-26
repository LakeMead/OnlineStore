namespace OnlineStore.Web.Areas.Administration_Products.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using OnlineStore.Data;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;
    using OnlineStore.Web.Controllers;
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