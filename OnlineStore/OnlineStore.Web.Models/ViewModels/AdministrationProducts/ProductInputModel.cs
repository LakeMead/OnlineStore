namespace OnlineStore.Web.Models.ViewModels.AdministrationProducts
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class ProductInputModel : IMapTo<Product>
    {
        public string Name { get; set; }

        [UIHint("TextArea")]
        public string Description { get; set; }

        [UIHint("DecimalPrice")]
        public decimal Price { get; set; }

        [UIHint("Integer")]
        public int Quantity { get; set; }

        [UIHint("ProductCategoriesDropDownModel")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [UIHint("Upload")]
        public HttpPostedFileBase Image { get; set; }
    }
}
