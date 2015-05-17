namespace OnlineStore.Data.Repositories.Contracts
{
    using System.Linq;

    using OnlineStore.Data.Contracts;
    using OnlineStore.Data.Models;

    public interface IWishProductRepository : IDeletableEntityRepository<WishProduct>
    {
        IQueryable<WishProduct> GetByUserId(string id);
    }
}
