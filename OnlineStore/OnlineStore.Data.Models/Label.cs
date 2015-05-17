namespace OnlineStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    using OnlineStore.Data.Contracts;

    public class Label : DeletableEntity, IAuditInfo
    {
        private ICollection<Product> products;

        public Label()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

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
