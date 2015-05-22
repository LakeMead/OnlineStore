namespace ShoppingCartProvider
{
    public interface IShoppingCartProvider
    {
        void AddToCart();
        void RemoveFromCart();
        void EmptyCart();
        void GetCartItems();
        void GetCount();
        void GetTotal();
        void CreateOrder();
        void GetCart();


    }
}
