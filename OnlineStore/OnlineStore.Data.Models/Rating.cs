namespace OnlineStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using OnlineStore.Common.Enumerations;
    using OnlineStore.Data.Contracts;

    public class Rating : DeletableEntity, IAuditInfo
    {
        public int Id { get; set; }

        public RatingType Type { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
