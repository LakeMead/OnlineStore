namespace OnlineStore.Web.Areas.Administration_Orders.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using OnlineStore.Data;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;
    using OnlineStore.Web.Controllers;
    using OnlineStore.Web.Models.ViewModels.Administration_Orders;

    public class OrdersController : KendoGridAdministrationController
    {
        public OrdersController(IOnlineStoreData data, IShoppingCartProvider shoppingCartProvider)
            : base(data, shoppingCartProvider)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, OrderDetailsGridViewModel model)
        {
            if (model != null)
            {
                this.Data.Orders.DeleteById(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.Orders.All().Project().To<OrderDetailsGridViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Orders.GetById(id) as T;
        }
    }
}