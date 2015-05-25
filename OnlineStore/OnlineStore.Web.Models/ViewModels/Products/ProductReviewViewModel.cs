namespace OnlineStore.Web.Models.ViewModels.Products
{
    using System;
    using AutoMapper;

    using OnlineStore.Common.Enumerations;
    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class ProductReviewViewModel : IMapFrom<Review>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Author { get; set; }
        
        public string Content { get; set; }

        public RatingType Rating { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Review, ProductReviewViewModel>()
                .ForMember(m => m.Rating, opt => opt.MapFrom(e => e.Rating.Type))
                .ForMember(m => m.Author, opt => opt.MapFrom(e => e.Author.UserName));
        }
    }
}
