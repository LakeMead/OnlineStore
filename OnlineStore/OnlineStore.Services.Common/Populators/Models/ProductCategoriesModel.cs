namespace OnlineStore.Services.Common.Populators.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class ProductsCategoriesModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public ProductsCategoriesModel()
        {
            this.SubCategories = new List<ProductsCategoriesModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        ////public string Url
        ////{
        ////    get
        ////    {
        ////        return string.IsNullOrWhiteSpace(this.Title) ? string.Empty : this.Title.ToUrl().ConvertCyrillicToLatinLetters();
        ////    }
        ////}

        public int ProductsCount { get; set; }

        public IEnumerable<ProductsCategoriesModel> SubCategories { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Category, ProductsCategoriesModel>()
                .ForMember(m => m.SubCategories, opt => opt.MapFrom(e => e.SubCategories.AsQueryable().OrderBy(x => x.Order)))
                .ForMember(
                    m => m.ProductsCount,
                    opt => opt.MapFrom(e =>
                        e.Products.Count(x => !x.IsDeleted) +
                        e.SubCategories.Sum(x => x.Products.Count(y => !y.IsDeleted))));
        }
    }
}