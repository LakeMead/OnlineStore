namespace OnlineStore.Web.Models.ViewModels.Base.Products
{
    using System.Collections.Generic;

    using OnlineStore.Services.Common.Populators.Models;

    public class ProductsIndexViewModel
    {
        public ProductsIndexViewModel()
        {
            this.Products = new List<ProductIndexViewModel>();
            this.Categories = new List<ProductsCategoriesModel>();
        }

        public IEnumerable<ProductIndexViewModel> Products { get; set; }

        public IEnumerable<ProductsCategoriesModel> Categories { get; set; }
    }
}
