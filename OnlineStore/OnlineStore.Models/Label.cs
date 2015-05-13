namespace OnlineStore.Models
{
    using System;
    using System.Collections.Generic;

    public class Label
    {
        private DateTime createdOn;

        private ICollection<Product> products;

        public Label()
        {
            this.createdOn = DateTime.Now;
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn
        {
            get { return this.createdOn; }
            set { this.createdOn = value; }
        }

        public ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
