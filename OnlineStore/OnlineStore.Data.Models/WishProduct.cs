namespace OnlineStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    using OnlineStore.Data.Contracts;

    public class WishProduct : DeletableEntity, IAuditInfo
    {
        private ICollection<User> users;

        public WishProduct()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
