using System.Web.Mvc;

namespace OnlineStore.Web.Controllers
{
    using OnlineStore.Data;

    using Color = OnlineStore.Models.Color;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new OnlineStoreDbContext();
            context.Colors.Add(new Color { Name = "Blue" });
            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}