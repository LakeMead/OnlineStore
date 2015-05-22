namespace OnlineStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnlineStore.Common.Enumerations;
    using OnlineStore.Data.Contracts;

    public class Order : DeletableEntity
    {
        private ICollection<Product> products;

        public Order()
        {
            this.products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Index]
        public OrderStatus OrderStatus { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int CustomerInfoId { get; set; }

        public virtual CustomerInfo CustomerInfo { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
