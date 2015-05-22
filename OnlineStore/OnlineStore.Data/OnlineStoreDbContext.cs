namespace OnlineStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using OnlineStore.Data.Contracts;
    using OnlineStore.Data.Models;

    using Attribute = OnlineStore.Data.Models.Attribute;

    public class OnlineStoreDbContext : IdentityDbContext<User>, IOnlineStoreDbContext
    {
        public OnlineStoreDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<OrderDetail> OrderDetails { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Label> Labels { get; set; }

        public IDbSet<Color> Colors { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<Attribute> Attributes { get; set; }

        public IDbSet<Discount> Discounts { get; set; }

        public IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<CustomerInfo> CustomerInfos { get; set; }

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

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
