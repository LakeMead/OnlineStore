namespace OnlineStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using OnlineStore.Data.Contracts;
    using OnlineStore.Data.Migrations;
    using OnlineStore.Data.Models;
    using OnlineStore.Data.Repositories;
    using OnlineStore.Data.Repositories.Contracts;

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

        public IOrderRepository Orders
        {
            get { return (IOrderRepository)this.GetDeletableEntityRepository<Order>(); }
        }

        public IProductsRepository Products
        {
            get { return (IProductsRepository)this.GetDeletableEntityRepository<Product>(); }
        }

        public IDeletableEntityRepository<Category> Categories
        {
            get { return this.GetDeletableEntityRepository<Category>(); }
        }

        public ILabelRepository Labels
        {
            get { return (ILabelRepository)this.GetDeletableEntityRepository<Label>(); }
        }

        public IGenericRepository<Color> Colors
        {
            get { return this.GetRepository<Color>(); }
        }

        public IDeletableEntityRepository<Review> Reviews
        {
            get { return this.GetDeletableEntityRepository<Review>(); }
        }

        public ICommentRepository Comments
        {
            get { return (ICommentRepository)this.GetDeletableEntityRepository<Comment>(); }
        }

        public IRatingRepository Ratings
        {
            get { return (IRatingRepository)this.GetDeletableEntityRepository<Rating>(); }
        }

        public IDeletableEntityRepository<Attribute> Attributes
        {
            get { return this.GetDeletableEntityRepository<Attribute>(); }
        }

        public IDeletableEntityRepository<Discount> Discounts
        {
            get { return this.GetDeletableEntityRepository<Discount>(); }
        }

        public IGenericRepository<City> Cities
        {
            get { return this.GetRepository<City>(); }
        }

        public IGenericRepository<Country> Countries
        {
            get { return this.GetRepository<Country>(); }
        }

        public IGenericRepository<Address> Addresses
        {
            get { return this.GetRepository<Address>(); }
        }

        public IDeletableEntityRepository<CustomerInfo> CustomerInfos
        {
            get { return this.GetDeletableEntityRepository<CustomerInfo>(); }
        }

        public IWishProductRepository WishProducts
        {
            get { return (IWishProductRepository)this.GetDeletableEntityRepository<WishProduct>(); }
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

        public IUserRepository Users
        {
            get { return (IUserRepository)this.GetDeletableEntityRepository<User>(); }
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

                if (typeof(T).IsAssignableFrom(typeof(Order)))
                {
                    type = typeof(OrderRepository);
                }

                if (typeof(T).IsAssignableFrom(typeof(Product)))
                {
                    type = typeof(ProductsRepository);
                }

                if (typeof(T).IsAssignableFrom(typeof(Label)))
                {
                    type = typeof(LabelRepository);
                }

                if (typeof(T).IsAssignableFrom(typeof(Comment)))
                {
                    type = typeof(CommentRepository);
                }

                if (typeof(T).IsAssignableFrom(typeof(Rating)))
                {
                    type = typeof(RatingRepository);
                }

                if (typeof(T).IsAssignableFrom(typeof(WishProduct)))
                {
                    type = typeof(WishProductRepository);
                }

                if (typeof(T).IsAssignableFrom(typeof(User)))
                {
                    type = typeof(UserRepository);
                }

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}