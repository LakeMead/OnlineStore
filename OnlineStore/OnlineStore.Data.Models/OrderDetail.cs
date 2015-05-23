namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using OnlineStore.Data.Contracts;

    public class OrderDetail : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
