namespace OnlineStore.Data.Repositories
{
    using System.Linq;

    using OnlineStore.Common.Enumerations;
    using OnlineStore.Data.Models;
    using OnlineStore.Data.Repositories.Contracts;

    public class OrderRepository : DeletableEntityRepository<Order>, IOrderRepository
    {
        public OrderRepository(IOnlineStoreDbContext context)
            : base(context)
        {
        }

        public IQueryable<Order> GetByOrderStatus(OrderStatus status)
        {
            return this.Context.Orders.Where(o => o.OrderStatus == status);
        }
    }
}
