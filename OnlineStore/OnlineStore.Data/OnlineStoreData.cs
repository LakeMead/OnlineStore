using System.Data.Entity;
using OnlineStore.Data.Migrations;

namespace OnlineStore.Data
{
    using System;
    using System.Collections.Generic;

    using OnlineStore.Data.Contracts;
    using OnlineStore.Data.Models;
    using OnlineStore.Data.Repositories;

    using Attribute = OnlineStore.Data.Models.Attribute;

    public class OnlineStoreData : IOnlineStoreData
    {
        private readonly IOnlineStoreDbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public OnlineStoreData(IOnlineStoreDbContext context)
        {
            this.context = context;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineStoreDbContext, Configuration>());
        }

        public IOnlineStoreDbContext Context
        {
            get { return this.context; }
        }

        public IDeletableEntityRepository<Order> Orders
        {
            get { return this.GetDeletableEntityRepository<Order>(); }
        }

        public IDeletableEntityRepository<Product> Products
        {
            get { return this.GetDeletableEntityRepository<Product>(); }
        }

        public IDeletableEntityRepository<Category> Categories
        {
            get { return this.GetDeletableEntityRepository<Category>(); }
        }

        public IDeletableEntityRepository<Label> Labels
        {
            get { return this.GetDeletableEntityRepository<Label>(); }
        }

        public IGenericRepository<Color> Colors
        {
            get { return this.GetRepository<Color>(); }
        }

        public IDeletableEntityRepository<Review> Reviews
        {
            get { return this.GetDeletableEntityRepository<Review>(); }
        }

        public IDeletableEntityRepository<Comment> Comments
        {
            get { return this.GetDeletableEntityRepository<Comment>(); }
        }

        public IDeletableEntityRepository<Rating> Ratings
        {
            get { return this.GetDeletableEntityRepository<Rating>(); }
        }

        public IDeletableEntityRepository<Attribute> Attributes
        {
            get { return this.GetDeletableEntityRepository<Attribute>(); }
        }

        public IDeletableEntityRepository<Discount> Discounts
        {
            get { return this.GetDeletableEntityRepository<Discount>(); }
        }

        public IDeletableEntityRepository<WishProduct> WishProducts
        {
            get { return this.GetDeletableEntityRepository<WishProduct>(); }
        }

        public IDeletableEntityRepository<ContactFormFeedback> ContactFormFeedbacks
        {
            get { return this.GetDeletableEntityRepository<ContactFormFeedback>(); }
        }

        public IDeletableEntityRepository<FrequentlyAskedQuestion> FrequentlyAskedQuestions
        {
            get { return this.GetDeletableEntityRepository<FrequentlyAskedQuestion>(); }
        }

        public IGenericRepository<StaticPage> StaticPages
        {
            get { return this.GetRepository<StaticPage>(); }
        }

        public IGenericRepository<StaticPageSection> StaticPageSections
        {
            get { return this.GetRepository<StaticPageSection>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity, new()
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}