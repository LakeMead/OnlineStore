namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using OnlineStore.Data.Contracts;

    public class ContactFormFeedback : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string Content { get; set; }
    }
}
