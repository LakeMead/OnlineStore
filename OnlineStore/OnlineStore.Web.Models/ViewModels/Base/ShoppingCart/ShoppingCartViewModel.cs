namespace OnlineStore.Web.Models.ViewModels.Base.ShoppingCart
{
    using System.Collections.Generic;

    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }

        public decimal CartTotal { get; set; }
    }
}
