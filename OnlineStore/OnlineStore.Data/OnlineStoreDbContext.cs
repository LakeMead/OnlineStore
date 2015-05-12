namespace OnlineStore.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using OnlineStore.Models;

    public class OnlineStoreDbContext : IdentityDbContext<User>
    {
        public OnlineStoreDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static OnlineStoreDbContext Create()
        {
            return new OnlineStoreDbContext();
        }
    }
}
