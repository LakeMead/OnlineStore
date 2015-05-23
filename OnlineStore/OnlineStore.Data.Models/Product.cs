namespace OnlineStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnlineStore.Data.Contracts;

    public class Product : DeletableEntity
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

        [Key]
        public int Id { get; set; }

        [Index]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string Description { get; set; }

        [Index]
        public decimal Price { get; set; }

        [Index]
        public int Quantity { get; set; }

        public int? DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string ImagePath { get; set; }

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
