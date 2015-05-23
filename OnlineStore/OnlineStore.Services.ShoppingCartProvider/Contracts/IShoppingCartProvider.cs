namespace OnlineStore.Services.ShoppingCartProvider.Contracts
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;

    using OnlineStore.Data.Models;
    using OnlineStore.Services.Common;

    public interface IShoppingCartProvider : IService
    {
        void AddToCart(Product product, int count);

        int RemoveFromCart(int id);

        void EmptyCart();

        List<ShoppingCart> GetCartItems();

        int GetCount();

        decimal GetTotal();

        int CreateOrder(Order order);

        string GetCartId(HttpContextBase context);

        ShoppingCartProvider GetCart(HttpContextBase context);

        ShoppingCartProvider GetCart(Controller controller);

        void MigrateCart(string userName);
    }
}