namespace OnlineStore.Web.Models.ViewModels.Base.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class ProductDetailsViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImagePath { get; set; }

        public decimal? DiscountPercent { get; set; }

        public IEnumerable<string> Colors { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<ProductReviewViewModel> Reviews { get; set; }
        
        public IEnumerable<ProductCommentViewModel> Comments { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductDetailsViewModel>()
                .ForMember(m => m.Colors, opt => opt.MapFrom(e => e.Colors.Select(c => c.Name)));
        }
    }
}
