namespace OnlineStore.Data.Repositories.Contracts
{
    using System.Linq;

    using OnlineStore.Common.Enumerations;
    using OnlineStore.Data.Contracts;
    using OnlineStore.Data.Models;

    public interface IOrderRepository : IDeletableEntityRepository<Order>
    {
        IQueryable<Order> GetByOrderStatus(OrderStatus status);
    }
}
