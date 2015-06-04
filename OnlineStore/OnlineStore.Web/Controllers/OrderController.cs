namespace OnlineStore.Web.Controllers
{
    using System.Web.Mvc;

    using OnlineStore.Web.Models.ViewModels.Base.Order;

    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View(new OrderInputModel());
        }

        [HttpPost]
        public ActionResult Index(OrderInputModel inputModel)
        {
            return this.View(inputModel);
        }
    }
}