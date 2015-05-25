namespace OnlineStore.Web.Models.ViewModels.Base.Home
{
    using System.Collections.Generic;

    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class HomeViewModel : IMapFrom<Product>
    {
        public IEnumerable<DiscountedProductsViewModel> DiscountedProducts { get; set; }

        public IEnumerable<NewestProductsViewModel> NewestProducts { get; set; }

        public IEnumerable<MostPopularProductsViewModel> MostPopularProducts { get; set; }

        public IEnumerable<TopRatedProductsViewModel> TopRatedProducts { get; set; }
    }
}
