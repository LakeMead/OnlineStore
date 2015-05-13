namespace OnlineStore.Models
{
    using System;
    using System.Collections.Generic;

    public class Product
    {
        private DateTime createdOn;

        private ICollection<Category> categories;

        private ICollection<Color> colors;

        private ICollection<Comment> comments;

        public Product()
        {
            this.createdOn = DateTime.Now;
            this.categories = new HashSet<Category>();
            this.colors = new HashSet<Color>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn
        {
            get { return this.createdOn; }
            set { this.createdOn = value; }
        }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public virtual ICollection<Color> Colors
        {
            get { return this.colors; }
            set { this.colors = value; }
        }

        public ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
