namespace OnlineStore.Data.Repositories.Contracts
{
    using System.Linq;

    using OnlineStore.Data.Contracts;
    using OnlineStore.Data.Models;

    public interface ILabelRepository : IDeletableEntityRepository<Label>
    {
        IQueryable<Label> GetByProductId(int id);
    }
}
