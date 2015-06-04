namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using OnlineStore.Data;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;
    using OnlineStore.Web.Models.ViewModels.Base.Order;
    using OnlineStore.Web.Models.ViewModels.Base.ShoppingCart;

    public class OrderController : BaseController
    {
        public OrderController(IOnlineStoreData data, IShoppingCartProvider shoppingCartProvider)
            : base(data, shoppingCartProvider)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var customerInfo = this.Data.Addresses
                .All()
                .Where(a => a.CustomerInfo.User.UserName == this.UserProfile.UserName)
                .Select(a => new OrderInputModel
                {
                    AddressName = a.City.Name,
                    PostalCode = a.PostalCode,
                    Street = a.Street,
                    FirstName = a.CustomerInfo.FirstName,
                    LastName = a.CustomerInfo.LastName,
                    CustomerInfoId = a.CustomerInfo.Id
                })
                .FirstOrDefault();

            this.ShoppingCartProvider.GetCart(this);

            var items = this.ShoppingCartProvider.GetCartItems()
                .AsQueryable()
                .Project()
                .To<ShoppingCartItemViewModel>()
                .ToList();

            var viewModel = new ShoppingCartViewModel
            {
                ShoppingCartItems = items,
                CartTotal = this.ShoppingCartProvider.GetTotal()
            };

            customerInfo.ShoppingCart = viewModel;

            return this.View(customerInfo);
        }

        [HttpPost]
        public ActionResult Index(OrderInputModel inputModel)
        {
            return this.View(inputModel);
        }
    }
}