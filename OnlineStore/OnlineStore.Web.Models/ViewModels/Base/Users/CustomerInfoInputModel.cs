namespace OnlineStore.Web.Models.ViewModels.Base.Users
{
    using OnlineStore.Common.Mapping;
    using OnlineStore.Data.Models;

    public class CustomerInfoInputModel : IMapTo<Address>
    {
        public string FistName { get; set; }

        public string LastName { get; set; }

        public int CityId { get; set; }

        public string PostalCode { get; set; }

        public string Street { get; set; }
    }
}
