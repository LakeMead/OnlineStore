namespace OnlineStore.Data.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class DeletableEntity : IDeletableEntity
    {
        [Editable(false)]
        public bool IsDeleted { get; set; }

        [Editable(false)]
        public DateTime? DeletedOn { get; set; }
    }
}
