namespace OnlineStore.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using OnlineStore.Data;
    using OnlineStore.Data.Models;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;

    public abstract class BaseController : Controller
    {
        protected BaseController(IOnlineStoreData data, IShoppingCartProvider shoppingCartProvider)
        {
            this.Data = data;
            this.ShoppingCartProvider = shoppingCartProvider;
        }

        protected IOnlineStoreData Data { get; private set; }

        protected IShoppingCartProvider ShoppingCartProvider { get; set; }

        protected User UserProfile { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.Data.Users
                                   .All()
                                   .FirstOrDefault(u => u.UserName == requestContext.HttpContext.User.Identity.Name);

            this.PopulateViewData();

            return base.BeginExecute(requestContext, callback, state);
        }

        private void PopulateViewData()
        {
            this.ViewData["ShoppingCartItemsCount"] = this.ShoppingCartProvider.GetCount();
        }
    }
}