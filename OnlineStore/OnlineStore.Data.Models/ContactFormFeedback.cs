namespace OnlineStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using OnlineStore.Data.Contracts;

    public class ContactFormFeedback : DeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
