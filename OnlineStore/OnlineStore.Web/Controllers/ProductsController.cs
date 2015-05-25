﻿namespace OnlineStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using OnlineStore.Data;
    using OnlineStore.Services.ShoppingCartProvider.Contracts;
    using OnlineStore.Web.Models.ViewModels.Products;

    public class ProductsController : BaseController
    {
        public ProductsController(IOnlineStoreData data, IShoppingCartProvider shoppingCartProvider)
            : base(data, shoppingCartProvider)
        {
        }

        public ActionResult Index()
        {
            var products = this.Data.Products.All().Project().To<ProductDetailsViewModel>().ToList();

            return this.View(products);
        }

        public ActionResult Details(int id)
        {
            var product = this.Data.Products.All().Where(x => x.Id == id).Project().To<ProductDetailsViewModel>().FirstOrDefault();

            return this.View(product);
        }
    }
}