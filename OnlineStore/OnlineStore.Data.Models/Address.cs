namespace OnlineStore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address
    {
        [ForeignKey("CustomerInfo")]
        public int Id { get; set; }

        // TODO: Investigate an exception that those properties throw
        ////public int CountryId { get; set; }

        ////public Country Country { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public CustomerInfo CustomerInfo { get; set; }

        public string PostalCode { get; set; }

        public string Street { get; set; }
    }
}
