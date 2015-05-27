namespace OnlineStore.Services.Common.Contracts
{
    using System.Collections.Generic;

    using OnlineStore.Services.Common.Populators.Models;

    public interface ICachePopulator : IService
    {
        IEnumerable<ProductsCategoriesModel> GetProductCategories(int cacheMinutes = 60);
    }
}