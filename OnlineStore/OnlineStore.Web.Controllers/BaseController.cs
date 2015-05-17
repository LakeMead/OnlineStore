namespace OnlineStore.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using OnlineStore.Data;
    using OnlineStore.Data.Models;

    public class BaseController : Controller
    {
        public BaseController(IOnlineStoreData data)
        {
            this.Data = data;
        }

        protected IOnlineStoreData Data { get; private set; }

        protected User UserProfile { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.Data.Users
                                   .All()
                                   .FirstOrDefault(u => u.UserName == requestContext.HttpContext.User.Identity.Name);

            return base.BeginExecute(requestContext, callback, state);
        }

    }
}