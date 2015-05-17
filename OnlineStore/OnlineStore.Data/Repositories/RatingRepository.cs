namespace OnlineStore.Data.Repositories
{
    using System.Linq;

    using OnlineStore.Data.Models;
    using OnlineStore.Data.Repositories.Contracts;

    public class RatingRepository : DeletableEntityRepository<Rating>, IRatingRepository
    {
        public RatingRepository(IOnlineStoreDbContext context)
            : base(context)
        {
        }

        public IQueryable<Rating> GetByAuthorId(string id)
        {
            return this.Context.Ratings.Where(r => r.AuthorId == id);
        }

        public IQueryable<Rating> GetByProductId(int id)
        {
            return this.Context.Ratings.Where(r => r.ProductId == id);
        }
    }
}
