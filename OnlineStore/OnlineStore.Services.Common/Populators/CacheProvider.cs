namespace OnlineStore.Services.Common.Populators
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using OnlineStore.Common.Constants;
    using OnlineStore.Data;
    using OnlineStore.Services.Common.Contracts;
    using OnlineStore.Services.Common.Populators.Models;

    public class CacheProvider : ICacheProvider
    {
        private readonly ICacheService cacheService;
        private readonly IOnlineStoreData data;

        public CacheProvider(IOnlineStoreData data, ICacheService cashService)
        {
            this.cacheService = cashService;
            this.data = data;
        }

        public IEnumerable<ProductsCategoriesModel> GetProductCategories(int cacheMinutes = 60)
        {
            var productCategories = this.cacheService.Get(
                CacheIds.ProductCategories,
                () =>
                {
                    var rawCategories = this.data.Categories
                        .All()
                        .Include(x => x.Products)
                        .Include(x => x.SubCategories)
                        .Include("SubCategories.Products")
                        .Where(x => !x.ParentCategoryId.HasValue)
                        .OrderBy(x => x.Order)
                        .ToList();

                    var categories = Mapper.Map<IEnumerable<ProductsCategoriesModel>>(rawCategories);
                    return categories;
                },
                cacheMinutes);

            return productCategories;
        }

        public IEnumerable<ProductCategoriesDropDownModel> GetDropDownProductsCategories(int cacheMinutes = 0)
        {
            var categories = this.cacheService.Get<IEnumerable<ProductCategoriesDropDownModel>>(
                CacheIds.ProductCategoriesDropDown,
                () =>
                {
                    return this.data.Categories
                        .All()
                        .Select(c => new ProductCategoriesDropDownModel
                        {
                            Id = c.Id,
                            Name = c.Name
                        })
                        .ToList();
                },
                0);

            return categories;
        }
    }
}
