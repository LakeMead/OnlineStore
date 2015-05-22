namespace OnlineStore.Web.Controllers
{
    using System.Web.Mvc;

    using OnlineStore.Data;

    public class ShoppingCartController : BaseController
    {
        public ShoppingCartController(IOnlineStoreData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}