namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnlineStore.Data.Contracts;

    public class Review : DeletableEntity
    {
        [ForeignKey("Rating")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
