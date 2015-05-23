namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using OnlineStore.Data;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;
    using OnlineStore.Web.Models.ViewModels.Home;

    [RequireHttps]
    public class HomeController : BaseController
    {
        public HomeController(IOnlineStoreData data, IShoppingCartProvider shoppingCartProvider)
            : base(data, shoppingCartProvider)
        {
        }

        public ActionResult Index()
        {
            var newestProduct = this.Data.Products.GetTheNewest().Where(np => np.Discount == null).Take(2).Project().To<NewestProductsViewModel>();
            var discountedProducts =
                this.Data.Products.GetDiscounted()
                    .OrderByDescending(p => p.CreatedOn)
                    .Take(2)
                    .Project()
                    .To<DiscountedProductsViewModel>();
            var mostPopularProducts =
                this.Data.Products.GetMostOrdered().Where(np => np.Discount == null).Take(2).Project().To<MostPopularProductsViewModel>();
            var topRatedProducts = this.Data.Products.GetMostRated().Where(np => np.Discount == null).Take(2).Project().To<TopRatedProductsViewModel>();

            var model = new HomeViewModel
                        {
                            NewestProducts = newestProduct,
                            DiscountedProducts = discountedProducts,
                            MostPopularProducts = mostPopularProducts,
                            TopRatedProducts = topRatedProducts
                        };
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