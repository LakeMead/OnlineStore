namespace OnlineStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnlineStore.Data.Contracts;

    public class Comment : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Index]
        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string Content { get; set; }
    }
}
