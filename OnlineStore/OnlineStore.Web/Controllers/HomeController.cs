namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using OnlineStore.Data;
    using OnlineStore.Web.Models.ViewModels.Home;

    [RequireHttps]
    public class HomeController : BaseController
    {
        public HomeController(IOnlineStoreData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var newestProduct = this.Data.Products.GetTheNewest().Project().To<NewestProductsViewModel>().Take(1);
            var model = new HomeViewModel { NewestProducts = newestProduct };
            return this.View(model);
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