namespace OnlineStore.Data.Repositories.Contracts
{
    using System.Linq;

    using OnlineStore.Data.Contracts;
    using OnlineStore.Data.Models;

    public interface IUserRepository : IDeletableEntityRepository<User>
    {
        IQueryable<Order> GetAllOrderedProducts(string id);

        IQueryable<User> GetAllWishProducts(string id);

        IQueryable<User> GetLastRegistered();

        IQueryable<User> SortedByOrdersCount();

        User GetByUsername(string username);
    }
}
