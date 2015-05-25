namespace OnlineStore.Web.Models.ViewModels.Base.ShoppingCart
{
    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class ShoppingCartItemViewModel : IMapFrom<ShoppingCart>
    {
        public int Count { get; set; }

        public int ProductId { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductImagePath { get; set; }

        public string ProductName { get; set; }
    }
}
