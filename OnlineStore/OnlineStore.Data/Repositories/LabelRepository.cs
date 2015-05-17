namespace OnlineStore.Data.Repositories
{
    using System.Linq;

    using OnlineStore.Data.Models;
    using OnlineStore.Data.Repositories.Contracts;

    public class LabelRepository : DeletableEntityRepository<Label>, ILabelRepository
    {
        public LabelRepository(IOnlineStoreDbContext context)
            : base(context)
        {
        }

        public IQueryable<Label> GetByProductId(int id)
        {
            return this.Context.Labels.Where(l => l.Products.Select(p => p.Id).Contains(id));
        }
    }
}
