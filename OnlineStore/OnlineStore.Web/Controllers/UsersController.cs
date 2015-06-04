namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using OnlineStore.Data;
    using OnlineStore.Data.Models;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;
    using OnlineStore.Web.Models.ViewModels.Base.Users;

    public class UsersController : BaseController
    {
        public UsersController(IOnlineStoreData data, IShoppingCartProvider shoppingCartProvider)
            : base(data, shoppingCartProvider)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult AddCustomerInfo()
        {
            this.ViewBag.Countries = this.Data.Countries
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });

            this.ViewBag.Cities = this.Data.Cities.All().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return this.View(new CustomerInfoInputModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomerInfo(CustomerInfoInputModel inputModel)
        {
            // TODO: Add validation
            if (this.ModelState.IsValid)
            {
                var customerInfo = new CustomerInfo
                {
                    FirstName = inputModel.FistName,
                    LastName = inputModel.LastName
                };

                this.Data.CustomerInfos.Add(customerInfo);
                this.Data.SaveChanges();

                var address = new Address
                {
                    CustomerInfo = customerInfo,
                    PostalCode = inputModel.PostalCode,
                    Street = inputModel.Street,
                    CityId = inputModel.CityId
                };

                this.Data.Addresses.Add(address);
                this.Data.SaveChanges();

                return this.RedirectToAction<UsersController, HomeController>(c => c.Index());
            }
            
            return this.View(inputModel);
        }
    }
}