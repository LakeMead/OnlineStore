namespace OnlineStore.Web.Models.ViewModels.Base.Order
{
    using OnlineStore.Web.Models.ViewModels.Base.ShoppingCart;

    public class OrderInputModel
    {
        public int CustomerInfoId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AddressName { get; set; }

        public string PostalCode { get; set; }

        public string Street { get; set; }

        public ShoppingCartViewModel ShoppingCart { get; set; }
    }
}
