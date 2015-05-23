namespace OnlineStore.Web.Models.ViewModels.ShoppingCart
{
    using System.Collections.Generic;

    using OnlineStore.Data.Models;

    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }

        public decimal CartTotal { get; set; }
    }
}
