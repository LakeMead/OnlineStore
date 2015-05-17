namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using OnlineStore.Data;
    using OnlineStore.Data.Models;

    [RequireHttps]
    public class HomeController : Controller
    {
        private IOnlineStoreData data;

        public HomeController(IOnlineStoreData data)
        {
            this.data = data;
        }

        public ActionResult Index()
        {
            var a = this.data.Colors.All().ToList();
            return this.View(a);
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