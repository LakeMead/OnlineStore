namespace OnlineStore.Web.Models.ViewModels.Home
{
    using System.Collections;
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<DiscountedProductsViewModel> DiscountedProducts { get; set; }

        public IEnumerable<NewestProductsViewModel> NewestProducts { get; set; }

        public IEnumerable<MostPopularProductsViewModel> MostPopularProducts { get; set; }

        //public IEnumerable<TopRatedProductsViewModel> TopRatedProducts { get; set; }
    }
}
