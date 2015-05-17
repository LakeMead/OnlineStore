namespace OnlineStore.Data.Repositories
{
    using System.Linq;

    using OnlineStore.Data.Models;
    using OnlineStore.Data.Repositories.Contracts;

    public class WishProductRepository : DeletableEntityRepository<WishProduct>, IWishProductRepository
    {
        public WishProductRepository(IOnlineStoreDbContext context)
            : base(context)
        {
        }

        public IQueryable<WishProduct> GetByUserId(string id)
        {
            return this.Context.WishProducts.Where(wp => wp.UserId == id);
        }
    }
}
