namespace OnlineStore.Web.Controllers
{
    using System.Web.Mvc;

    using OnlineStore.Data;
    using OnlineStore.Models;

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
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}