namespace OnlineStore.Web.Models.ViewModels.AdministrationProducts
{
    using System.ComponentModel.DataAnnotations;

    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class ProductGridViewModel : IMapFrom<Product>
    {
        [Display(Name = "№")]
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }
    }
}
