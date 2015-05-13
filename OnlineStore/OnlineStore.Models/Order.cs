namespace OnlineStore.Models
{
    using System.Collections.Generic;

    using OnlineStore.Data.Contracts;

    public class Order : DeletableEntity
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

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
