namespace OnlineStore.Data.Models
{
    using System;

    using OnlineStore.Data.Contracts;

    public class FrequentlyAskedQuestion : DeletableEntity, IAuditInfo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int? Order { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
