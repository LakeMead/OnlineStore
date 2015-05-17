﻿namespace OnlineStore.Data.Models
{
    using System;
    using System.Collections.Generic;

    using OnlineStore.Data.Contracts;

    public class WishProduct : DeletableEntity
    {
        private ICollection<User> users;

        private DateTime createdOn;

        public WishProduct()
        {
            this.users = new HashSet<User>();
            this.createdOn = DateTime.Now;
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public DateTime CreatedOn
        {
            get { return this.createdOn; }
            set { this.createdOn = value; }
        }

        public string Comment { get; set; }
    }
}