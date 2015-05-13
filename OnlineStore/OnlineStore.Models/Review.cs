namespace OnlineStore.Models
{
    using System;

    public class Review
    {
        private DateTime createdOn;

        public Review()
        {
            this.createdOn = DateTime.Now;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public DateTime CreatedOn
        {
            get { return this.createdOn; }
            set { this.createdOn = value; }
        }

        // TODO: needs to be optional
        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
