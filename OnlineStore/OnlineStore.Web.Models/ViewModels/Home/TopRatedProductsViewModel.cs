namespace OnlineStore.Web.Models.ViewModels.Home
{
    using System.Linq;

    using AutoMapper;

    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class TopRatedProductsViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public double? Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, TopRatedProductsViewModel>()
                .ForMember(m => m.Rating, opt => opt.MapFrom(e => e.Ratings.Average(r => (int)r.Type)));
        }
    }
}
