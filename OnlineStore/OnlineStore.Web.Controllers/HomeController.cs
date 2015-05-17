namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using OnlineStore.Data;

    [RequireHttps]
    public class HomeController : BaseController
    {
        public HomeController(IOnlineStoreData data) : base (data)
        {
        }

        public ActionResult Index()
        {
            var a = this.Data.Colors.All().ToList(); 
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