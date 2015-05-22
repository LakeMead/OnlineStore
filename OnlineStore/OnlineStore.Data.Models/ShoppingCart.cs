namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using OnlineStore.Data.Contracts;

    public class ShoppingCart : AuditInfo
    {
        [Key]
        public int RecordId { get; set; }

        public string CartId { get; set; }

        public int Count { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
