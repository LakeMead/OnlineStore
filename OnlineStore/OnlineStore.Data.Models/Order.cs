namespace OnlineStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnlineStore.Common.Enumerations;
    using OnlineStore.Data.Contracts;

    public class Order : DeletableEntity, IAuditInfo
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
