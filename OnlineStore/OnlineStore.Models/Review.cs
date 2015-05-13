namespace OnlineStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnlineStore.Data.Contracts;

    public class Review : DeletableEntity
    {
        private DateTime createdOn;

        public Review()
        {
            this.createdOn = DateTime.Now;
        }

        [ForeignKey("Rating")]
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

        public virtual Rating Rating { get; set; }
    }
}
