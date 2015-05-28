namespace OnlineStore.Web.Infrastructure.Filters
{
    using System.Web.Mvc;

    using OnlineStore.Common.Constants;
    using OnlineStore.Services.Common.Contracts;

    public class ProductsCategoriesDropDownFilter : IActionFilter
    {
        private readonly ICacheProvider cacheProvider;

        public ProductsCategoriesDropDownFilter(ICacheProvider cacheProvider)
        {
            this.cacheProvider = cacheProvider;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewData[CacheIds.ProductCategoriesDropDown] = this.cacheProvider.GetDropDownProductsCategories();
        }

    }
}
