namespace OnlineStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    using OnlineStore.Common.Enumerations;
    using OnlineStore.Data.Contracts;

    public class Order : DeletableEntity, IAuditInfo
    {
        private ICollection<Product> products;

        public Order()
        {
            this.products = new HashSet<Product>();
        }

        // TODO: add more functionality?!?
        public int Id { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
