namespace OnlineStore.Data.Repositories.Contracts
{
    using System.Linq;

    using OnlineStore.Data.Contracts;
    using OnlineStore.Data.Models;

    public interface ICommentRepository : IDeletableEntityRepository<Comment>
    {
        IQueryable<Comment> GetByAuthorId(string id);

        IQueryable<Comment> GetByProductId(int id);
    }
}
