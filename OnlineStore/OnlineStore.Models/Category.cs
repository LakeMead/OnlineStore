namespace OnlineStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using OnlineStore.Data.Contracts;

    public class Category : DeletableEntity
    {
        private ICollection<Product> products;

        private DateTime createdOn;

        public Category()
        {
            this.products = new HashSet<Product>();
            this.createdOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Order { get; set; }

        public DateTime CreatedOn
        {
            get { return this.createdOn; }
            set { this.createdOn = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
