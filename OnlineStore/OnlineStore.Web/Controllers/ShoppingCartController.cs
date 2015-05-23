namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using OnlineStore.Data;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;

    public class ShoppingCartController : BaseController
    {
        private IShoppingCartProvider shoppingCartService;

        public ShoppingCartController(IOnlineStoreData data, IShoppingCartProvider shoppingCartService) : base(data)
        {
            this.shoppingCartService = shoppingCartService;
        }

        public ActionResult Index()
        {
            var cart = this.shoppingCartService.GetCart(this);
            var product = this.Data.Products.All().FirstOrDefault();
            this.shoppingCartService.AddToCart(product, 2);

            var cart2 = this.shoppingCartService.GetCartItems();
            var countItems = this.shoppingCartService.GetCount();
            var totalPrice = this.shoppingCartService.GetTotal();
            return this.View();
        }
    }
}