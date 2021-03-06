﻿namespace OnlineStore.Web.Infrastructure.Filters
{
    using System.Web.Mvc;

    using OnlineStore.Common.Constants;
    using OnlineStore.Services.Common.Contracts;

    public class ProductsCategoriesCacheFilter : IActionFilter
    {
        private readonly ICacheProvider cacheProvider;

        public ProductsCategoriesCacheFilter(ICacheProvider cacheProvider)
        {
            this.cacheProvider = cacheProvider;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewData[CacheIds.ProductCategories] = this.cacheProvider.GetProductCategories();
        }
    }
}
