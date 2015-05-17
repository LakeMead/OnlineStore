namespace OnlineStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using OnlineStore.Data.Contracts;

    public class Comment : DeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
