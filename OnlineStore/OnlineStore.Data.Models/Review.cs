namespace OnlineStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnlineStore.Data.Contracts;

    public class Review : DeletableEntity, IAuditInfo
    {
        [ForeignKey("Rating")]
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Rating Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
