namespace OnlineStore.Models
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

        private ICollection<WishProduct> wishProducts;

        public User()
        {
            this.comments = new HashSet<Comment>();
            this.reviews = new HashSet<Review>();
            this.ratings = new HashSet<Rating>();
            this.wishProducts = new HashSet<WishProduct>();
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
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

        [Editable(false)]
        public bool IsDeleted { get; set; }

        [Editable(false)]
        public DateTime? DeletedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}