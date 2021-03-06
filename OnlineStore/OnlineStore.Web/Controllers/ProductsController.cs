﻿namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using AutoMapper.QueryableExtensions;

    using OnlineStore.Common.Constants;
    using OnlineStore.Data;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;
    using OnlineStore.Web.Infrastructure.Attributes;
    using OnlineStore.Web.Models.ViewModels.Base.Products;

    public class ProductsController : BaseController
    {
        public ProductsController(IOnlineStoreData data, IShoppingCartProvider shoppingCartProvider)
            : base(data, shoppingCartProvider)
        {
        }

        [PopulateFromCache(CacheIds.ProductCategories)]
        public ActionResult Index()
        {
            var products = this.Data.Products.All().Project().To<ProductIndexViewModel>().ToList();
            var viewModel = new ProductsIndexViewModel { Products = products };

            return this.View(viewModel);
        }
        
        public ActionResult Details(int id)
        {
            var product = this.Data.Products.All().Where(x => x.Id == id).Project().To<ProductDetailsViewModel>().FirstOrDefault();

            if (product == null)
            {
                return this.RedirectToAction(c => c.Index());
            }

            return this.View(product);
        }
    }
}