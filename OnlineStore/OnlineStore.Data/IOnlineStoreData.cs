namespace OnlineStore.Data
{
    using OnlineStore.Data.Contracts;
    using OnlineStore.Data.Models;
    using OnlineStore.Data.Repositories.Contracts;

    public interface IOnlineStoreData
    {
        IOnlineStoreDbContext Context { get; }

        IOrderRepository Orders { get; }

        IProductsRepository Products { get; }

        IDeletableEntityRepository<Category> Categories { get; }

        ILabelRepository Labels { get; }

        IGenericRepository<Color> Colors { get; }

        IDeletableEntityRepository<Review> Reviews { get; }

        ICommentRepository Comments { get; }

        IRatingRepository Ratings { get; }

        IDeletableEntityRepository<Attribute> Attributes { get; }

        IDeletableEntityRepository<Discount> Discounts { get; }

        IGenericRepository<City> Cities { get; }

        IGenericRepository<Country> Countries { get; }

        IGenericRepository<Address> Addresses { get; }

        IDeletableEntityRepository<CustomerInfo> CustomerInfos { get; }

        IWishProductRepository WishProducts { get; }

        IDeletableEntityRepository<ContactFormFeedback> ContactFormFeedbacks { get; }

        IDeletableEntityRepository<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; }

        IGenericRepository<StaticPage> StaticPages { get; }

        IGenericRepository<StaticPageSection> StaticPageSections { get; }

        IUserRepository Users { get; }

        int SaveChanges();
    }
}
