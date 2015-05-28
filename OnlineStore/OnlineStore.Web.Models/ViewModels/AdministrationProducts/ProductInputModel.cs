namespace OnlineStore.Web.Models.ViewModels.AdministrationProducts
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class ProductInputModel : IMapTo<Product>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [UIHint("DecimalPrice")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [UIHint("ProductCategoriesDropDownModel")]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        [UIHint("Upload")]
        public HttpPostedFileBase Image { get; set; }
    }
}
