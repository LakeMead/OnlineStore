﻿namespace OnlineStore.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using OnlineStore.Data.Models;

    public interface IOnlineStoreDbContext
    {
        IDbSet<Order> Orders { get; set; }

        IDbSet<OrderDetail> OrderDetails { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Label> Labels { get; set; }

        IDbSet<Color> Colors { get; set; }

        IDbSet<Review> Reviews { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        IDbSet<Attribute> Attributes { get; set; }

        IDbSet<Discount> Discounts { get; set; }

        IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        IDbSet<Address> Addresses { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<CustomerInfo> CustomerInfos { get; set; }

        IDbSet<WishProduct> WishProducts { get; set; }

        IDbSet<ContactFormFeedback> ContactFormFeedbacks { get; set; }

        IDbSet<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }

        IDbSet<StaticPage> StaticPages { get; set; }

        IDbSet<StaticPageSection> StaticPageSections { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
