namespace OnlineStore.Data.Repositories.Contracts
{
    using System.Linq;

    using OnlineStore.Data.Contracts;
    using OnlineStore.Data.Models;

    public interface IRatingRepository : IDeletableEntityRepository<Rating>
    {
        IQueryable<Rating> GetByAuthorId(string id);

        IQueryable<Rating> GetByProductId(int id);
    }
}
