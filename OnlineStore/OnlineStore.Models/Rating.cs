﻿namespace OnlineStore.Models
{
    using OnlineStore.Data.Contracts;

    public class Rating : DeletableEntity
    {
        public int Id { get; set; }

        public RatingTypes Types { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }
    }
}