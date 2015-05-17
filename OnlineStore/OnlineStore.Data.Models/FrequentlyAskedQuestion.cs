namespace OnlineStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using OnlineStore.Data.Contracts;

    public class FrequentlyAskedQuestion : DeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string Content { get; set; }

        public int? DisplayOrder { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
