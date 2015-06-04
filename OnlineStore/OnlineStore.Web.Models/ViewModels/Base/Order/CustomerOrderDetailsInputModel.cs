namespace OnlineStore.Web.Models.ViewModels.Base.Order
{
    using OnlineStore.Data.Models;

    public class CustomerOrderDetailsInputModel
    {
        public int CustomerIn { get; set; }

        public Address Address { get; set; }
    }
}
