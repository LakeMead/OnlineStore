namespace OnlineStore.Web.Models.ViewModels.Home
{
    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class DiscountedProductsViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        public string ImagePath { get; set; }
    }
}
