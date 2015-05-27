namespace OnlineStore.Web.Infrastructure.Filters
{
    using System.Web.Mvc;

    using OnlineStore.Common.Constants;
    using OnlineStore.Services.Common.Contracts;

    public class ProductsCategoriesCacheFilter : IActionFilter
    {
        private readonly ICachePopulator cachePopulator;

        public ProductsCategoriesCacheFilter(ICachePopulator cachePopulator)
        {
            this.cachePopulator = cachePopulator;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewData[CacheIds.ProductCategories] = this.cachePopulator.GetProductCategories();
        }
    }
}
