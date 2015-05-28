namespace OnlineStore.Services.Common.Contracts
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using OnlineStore.Services.Common.Populators.Models;

    public interface ICacheProvider : IService
    {
        IEnumerable<ProductsCategoriesModel> GetProductCategories(int cacheMinutes = 60);

        IEnumerable<ProductCategoriesDropDownModel> GetDropDownProductsCategories(int cacheMinutes = 0);
    }
}