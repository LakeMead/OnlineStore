namespace OnlineStore.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using OnlineStore.Data.Models;

    public class OnlineStoreDbContext : IdentityDbContext<User>, IOnlineStoreDbContext
    {
        public OnlineStoreDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Label> Labels { get; set; }

        public IDbSet<Color> Colors { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<Attribute> Attributes { get; set; }

        public IDbSet<Discount> Discounts { get; set; }

        public IDbSet<WishProduct> WishProducts { get; set; }

        public IDbSet<ContactFormFeedback> ContactFormFeedbacks { get; set; }

        public IDbSet<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }

        public IDbSet<StaticPage> StaticPages { get; set; }

        public IDbSet<StaticPageSection> StaticPageSections { get; set; }

        public static OnlineStoreDbContext Create()
        {
            return new OnlineStoreDbContext();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
