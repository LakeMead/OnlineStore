namespace OnlineStore.Web.Models.ViewModels.Base.Products
{
    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class ProductIndexViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public decimal? DiscountPercent { get; set; }
    }
}
