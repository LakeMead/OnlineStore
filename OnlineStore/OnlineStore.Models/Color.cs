namespace OnlineStore.Models
{
    using System.Collections.Generic;

    public class Color
    {
        private ICollection<Product> products;

        public Color()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
