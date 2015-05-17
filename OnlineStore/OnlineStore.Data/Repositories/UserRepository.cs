namespace OnlineStore.Data.Repositories
{
    using System;
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

        public IQueryable<User> GetAllWishProducts(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetLastRegistered()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> SortedByOrdersCount()
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
