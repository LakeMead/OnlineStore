namespace OnlineStore.Data.Repositories
{
    using System.Linq;

    using OnlineStore.Data.Models;
    using OnlineStore.Data.Repositories.Contracts;

    public class UserRepository : DeletableEntityRepository<User>, IUserRepository
    {
        public UserRepository(IOnlineStoreDbContext context) : base(context)
        {
        }

        public IQueryable<Order> GetAllOrderedProducts(string id)
        {
            return this.Context.Orders.Where(o => o.UserId == id);
        }

        public IQueryable<WishProduct> GetAllWishProducts(string id)
        {
            return this.Context.WishProducts.Where(wp => wp.UserId == id);
        }

        ////public IQueryable<User> GetLastRegistered()
        ////{
        ////    return this.All().OrderByDescending(u => u.CreatedOn);
        ////}

        public IQueryable<User> SortedByOrdersCount()
        {
            return this.All().OrderByDescending(u => u.Orders.Count);
        }

        public User GetByUsername(string username)
        {
            return this.All().FirstOrDefault(u => u.UserName == username);
        }
    }
}
