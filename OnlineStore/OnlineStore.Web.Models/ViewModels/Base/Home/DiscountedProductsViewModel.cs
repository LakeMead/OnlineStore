namespace OnlineStore.Web.Models.ViewModels.Base.Home
{
    using AutoMapper;

    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class DiscountedProductsViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal NewPrice { get; set; }

        public int? DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        public string ImagePath { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, DiscountedProductsViewModel>()
                .ForMember(m => m.NewPrice, opt => opt.MapFrom(e => e.Price * e.Discount.Percent / 100));
        }
    }
}
