namespace OnlineStore.Models
{
    using System;

    public class Comment
    {
        private DateTime createdOn;

        public Comment()
        {
            this.createdOn = DateTime.Now;
        }

        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn
        {
            get { return this.createdOn; }
            set { this.createdOn = value; }
        }
    }
}
