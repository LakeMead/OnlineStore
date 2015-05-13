namespace OnlineStore.Data
{
    using OnlineStore.Data.Contracts;
    using OnlineStore.Models;

    public interface IOnlineStoreData
    {
        IOnlineStoreDbContext Context { get; }

        IDeletableEntityRepository<Order> Orders { get; }

        IDeletableEntityRepository<Product> Products { get; }

        IDeletableEntityRepository<Category> Categories { get; }

        IDeletableEntityRepository<Label> Labels { get; }

        IGenericRepository<Color> Colors { get; }

        IDeletableEntityRepository<Review> Reviews { get; }

        IDeletableEntityRepository<Comment> Comments { get; }

        IDeletableEntityRepository<Rating> Ratings { get; }

        IDeletableEntityRepository<Attribute> Attributes { get; }

        IDeletableEntityRepository<Discount> Discounts { get; }

        IDeletableEntityRepository<WishProduct> WishProducts { get; }

        IDeletableEntityRepository<ContactFormFeedback> ContactFormFeedbacks { get; }

        IDeletableEntityRepository<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; }

        IGenericRepository<StaticPage> StaticPages { get; }

        IGenericRepository<StaticPageSection> StaticPageSections { get; }

        int SaveChanges();
    }
}
