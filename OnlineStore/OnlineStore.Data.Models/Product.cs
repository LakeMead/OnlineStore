namespace OnlineStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    using OnlineStore.Data.Contracts;

    public class Product : DeletableEntity, IAuditInfo
    {
        private ICollection<Color> colors;

        private ICollection<Comment> comments;

        private ICollection<Label> labels;

        private ICollection<Review> reviews;

        private ICollection<Rating> ratings;

        private ICollection<WishProduct> wishProducts;

        private ICollection<Order> orders;

        public Product()
        {
            this.colors = new HashSet<Color>();
            this.comments = new HashSet<Comment>();
            this.labels = new HashSet<Label>();
            this.reviews = new HashSet<Review>();
            this.ratings = new HashSet<Rating>();
            this.wishProducts = new HashSet<WishProduct>();
            this.orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int? DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string ImagePath { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Color> Colors
        {
            get { return this.colors; }
            set { this.colors = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Label> Labels
        {
            get { return this.labels; }
            set { this.labels = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<WishProduct> WishProducts
        {
            get { return this.wishProducts; }
            set { this.wishProducts = value; }
        }

        public virtual ICollection<Order> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }
    }
}
