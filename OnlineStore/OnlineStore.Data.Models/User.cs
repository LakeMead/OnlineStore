namespace OnlineStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using OnlineStore.Data.Contracts;

    public class User : IdentityUser, IDeletableEntity
    {
        private ICollection<Comment> comments;

        private ICollection<Review> reviews;

        private ICollection<Rating> ratings;

        private ICollection<Order> orders;

        private ICollection<WishProduct> wishProducts;

        private ICollection<CustomerInfo> customerInfos;

        public User()
        {
            this.CreatedOn = DateTime.Now;
            this.comments = new HashSet<Comment>();
            this.orders = new HashSet<Order>();
            this.reviews = new HashSet<Review>();
            this.ratings = new HashSet<Rating>();
            this.wishProducts = new HashSet<WishProduct>();
            this.customerInfos = new HashSet<CustomerInfo>();
        }

        [Editable(false)]
        public bool IsDeleted { get; set; }

        [Editable(false)]
        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Order> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
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

        public virtual ICollection<CustomerInfo> CustomerInfos
        {
            get { return this.customerInfos; }
            set { this.customerInfos = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}