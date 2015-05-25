namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using OnlineStore.Data;
    using OnlineStore.Services.ImageManagement.Contracts;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;
    using OnlineStore.Web.Models.ViewModels.Base.ShoppingCart;

    public class ShoppingCartController : BaseController
    {
        private readonly IImageSaverService saverService;
        private readonly IImageResizerService resizerService;

        public ShoppingCartController(IOnlineStoreData data, IShoppingCartProvider shoppingCartProvider, IImageSaverService imageSaverService, IImageResizerService resizerService)
            : base(data, shoppingCartProvider)
        {
            this.saverService = imageSaverService;
            this.resizerService = resizerService;
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
            var name = image.FileName;

            // Test file upload
            this.resizerService.Resize(stream, 200, 200, "png", "max"); 
            return this.View();
        }
    }
}