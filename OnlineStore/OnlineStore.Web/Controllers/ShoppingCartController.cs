namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper.QueryableExtensions;

    using OnlineStore.Common.Enumerations;
    using OnlineStore.Data;
    using OnlineStore.Data.Models;
    using OnlineStore.Services.ImageManagement.Contracts;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;
    using OnlineStore.Web.Models.ViewModels.Base.Order;
    using OnlineStore.Web.Models.ViewModels.Base.ShoppingCart;

    public class ShoppingCartController : BaseController
    {
        private readonly IImageManipulatingService manipulatingService;

        public ShoppingCartController(IOnlineStoreData data, IShoppingCartProvider shoppingCartProvider, IImageManipulatingService manipulatingService)
            : base(data, shoppingCartProvider)
        {
            this.manipulatingService = manipulatingService;
        }

        ////public ActionResult Index()
        ////{
        ////    var cart = this.ShoppingCartProvider.GetCart(this);
        ////    var product = this.Data.Products.All().FirstOrDefault(x => x.Id == 7);
        ////    this.ShoppingCartProvider.AddToCart(product, 2);

        ////    var cart2 = this.ShoppingCartProvider.GetCartItems();
        ////    var countItems = this.ShoppingCartProvider.GetCount();
        ////    var totalPrice = this.ShoppingCartProvider.GetTotal();

        ////    return this.View();
        ////}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(int id, int quantity)
        {
            this.ShoppingCartProvider.GetCart(this);
            var product = this.Data.Products.All().FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                this.ShoppingCartProvider.AddToCart(product, quantity);
            }

            return this.Json("You successfully added product to shopping cart", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetItems()
        {
            this.ShoppingCartProvider.GetCart(this);

            var shoppingCartItems = this.ShoppingCartProvider
                .GetCartItems()
                .AsQueryable()
                .Project()
                .To<ShoppingCartItemViewModel>()
                .ToList();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var productDirectoryPath = this.manipulatingService.GetProductImageDirectory(shoppingCartItem.ProductId);
                var productName = this.manipulatingService.GetFirstThumbnailPath(productDirectoryPath);
                shoppingCartItem.ProductImagePath = productDirectoryPath + productName;
            }

            var viewModel = new ShoppingCartViewModel
            {
                ShoppingCartItems = shoppingCartItems,
                CartTotal = this.ShoppingCartProvider.GetTotal()
            };

            return this.PartialView("_ShoppingCartItems", viewModel);
        }

        [HttpPost]
        public ActionResult AddImage(string something, HttpPostedFileBase image)
        {
            var stream = image.InputStream;
            var imageWidth = 0;
            var imageHeight = 0;

            using (var picture = System.Drawing.Image.FromStream(stream, true, true))
            {
                imageWidth = picture.Width;
                imageHeight = picture.Height;
            }

            var name = image.FileName;

            //// Test file upload
            ////this.manipulatingService.ResizeAndSave(stream, 200, 200, "png", "max", "~/uploads/products/file"); 
            return this.View();
        }

        [HttpPost]
        public ActionResult Buy()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction<ShoppingCartController, AccountController>(c => c.Register());
            }

            this.ShoppingCartProvider.GetCart(this);

            var order = new Order
            {
                CustomerInfo = this.Data.CustomerInfos.All().FirstOrDefault(x => x.UserId == this.UserProfile.Id),
                OrderStatus = OrderStatus.NotProcessed,
                Total = this.ShoppingCartProvider.GetTotal()
            };

            this.Data.Orders.Add(order);
            this.Data.SaveChanges();

            var orderId = this.ShoppingCartProvider.CreateOrder(order);

            return this.RedirectToAction<ShoppingCartController, HomeController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult DeleteAllItems()
        {
            this.ShoppingCartProvider.GetCart(this);

            this.ShoppingCartProvider.EmptyCart();
            return new EmptyResult();
        }
    }
}