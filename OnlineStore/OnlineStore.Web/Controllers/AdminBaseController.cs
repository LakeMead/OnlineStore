namespace OnlineStore.Web.Controllers
{
    using OnlineStore.Data;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;

    // [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminBaseController : BaseController
    {
        public AdminBaseController(IOnlineStoreData data, IShoppingCartProvider shoppingCartProvider)
            : base(data, shoppingCartProvider)
        {
        }
    }
}