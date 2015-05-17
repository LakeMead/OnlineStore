namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using OnlineStore.Data;
    using OnlineStore.Data.Models;

    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new OnlineStoreDbContext();

            //context.Colors.Add(new Color { Name = "Blueblue" });
            //context.SaveChanges();
            var a = context.Colors.ToList();
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