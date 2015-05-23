namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using OnlineStore.Data.Contracts;

    public class CustomerInfo : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
