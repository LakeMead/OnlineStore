namespace OnlineStore.Data.Repositories
{
    using System.Linq;

    using OnlineStore.Data.Models;
    using OnlineStore.Data.Repositories.Contracts;

    public class CommentRepository : DeletableEntityRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IOnlineStoreDbContext context)
            : base(context)
        {
        }

        public IQueryable<Comment> GetByAuthorId(string id)
        {
            return this.Context.Comments.Where(c => c.AuthorId.Equals(id));
        }

        public IQueryable<Comment> GetByProductId(int id)
        {
            return this.Context.Comments.Where(c => c.ProductId == id);
        }
    }
}
