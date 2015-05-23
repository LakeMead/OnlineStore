namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using OnlineStore.Data;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;

    public class ShoppingCartController : BaseController
    {
        public ShoppingCartController(IOnlineStoreData data , IShoppingCartProvider shoppingCartProvider)
            : base(data, shoppingCartProvider)
        {
        }

        public ActionResult Index()
        {
            var cart = this.ShoppingCartProvider.GetCart(this);
            var product = this.Data.Products.All().FirstOrDefault();
            this.ShoppingCartProvider.AddToCart(product, 2);

            var cart2 = this.ShoppingCartProvider.GetCartItems();
            var countItems = this.ShoppingCartProvider.GetCount();
            var totalPrice = this.ShoppingCartProvider.GetTotal();

            return this.View();
        }
    }
}