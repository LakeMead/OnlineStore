namespace OnlineStore.Web.Models.ViewModels.AdministrationProducts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using OnlineStore.Common.Constants;
    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class ProductInputModel : IMapTo<Product>
    {
        [Display(Name = "Име на продукта")]
        [StringLength(
            ValidationConstants.ProductNameMaxLength, 
            MinimumLength = ValidationConstants.ProductNameMinLength,
            ErrorMessage = ErrorMessages.ProductNameLengthErrorMessage)]
        public string Name { get; set; }

        [UIHint("TextArea")]
        [StringLength(
            ValidationConstants.ProductDescriptionMaxLength,
            MinimumLength = ValidationConstants.ProductDescriptionMinLength,
            ErrorMessage = ErrorMessages.ProductDescriptionLengthErrorMessage)]
        public string Description { get; set; }

        [UIHint("DecimalPrice")]
        [Range(
            ValidationConstants.ProductMinPrice, 
            ValidationConstants.ProductMaxPrice, 
            ErrorMessage = ErrorMessages.ProductPriceErrorMessage)]
        public decimal Price { get; set; }

        [UIHint("Integer")]
        [Range(
            ValidationConstants.ProductMinQuantity,
            ValidationConstants.ProductMaxQuantity,
            ErrorMessage = ErrorMessages.ProductQuantityErrorMessage)]
        public int Quantity { get; set; }

        [UIHint("ProductCategoriesDropDownModel")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [UIHint("Upload")]
        public HttpPostedFileBase Image { get; set; }
    }
}
