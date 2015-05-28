namespace OnlineStore.Web.Config.NinjectConfig.Registries
{
    using System.Linq;
    using System.Web.Mvc;

    using Ninject;
    using Ninject.Web.Mvc.FilterBindingSyntax;

    using OnlineStore.Common.Constants;
    using OnlineStore.Web.Config.Registries.Contracts;
    using OnlineStore.Web.Infrastructure.Attributes;
    using OnlineStore.Web.Infrastructure.Filters;

    public class FiltersRegistry : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.BindFilter<ProductsCategoriesCacheFilter>(FilterScope.Action, 0)
               .When((controllerContext, actionDescriptor) => actionDescriptor
                   .GetCustomAttributes(typeof(PopulateFromCacheAttribute), true)
                   .Any(attr => ((PopulateFromCacheAttribute)attr).ViewBagPropIds.Contains(CacheIds.ProductCategories)));

            kernel.BindFilter<ProductsCategoriesDropDownFilter>(FilterScope.Action, 0)
              .When((controllerContext, actionDescriptor) => actionDescriptor
                  .GetCustomAttributes(typeof(PopulateFromCacheAttribute), true)
                  .Any(attr => ((PopulateFromCacheAttribute)attr).ViewBagPropIds.Contains(CacheIds.ProductCategoriesDropDown)));
        }
    }
}
