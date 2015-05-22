namespace ShoppingCartProvider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using global::ShoppingCartProvider.Contracts;

    using OnlineStore.Data;
    using OnlineStore.Data.Models;

    public class ShoppingCartProvider : IShoppingCartProvider
    {
        private const string CartSessionKey = "CartId";

        private IOnlineStoreData data;

        public ShoppingCartProvider(IOnlineStoreData data)
        {
            this.data = data;
        }

        public string ShoppingCartId { get; set; }

        public void AddToCart(Product product, int count)
        {
            var cartItem = this.data.ShoppingCarts.All().FirstOrDefault(
                c => c.CartId == this.ShoppingCartId
                && c.ProductId == product.Id);

            if (cartItem == null)
            {
                cartItem = new ShoppingCart
                {
                    ProductId = product.Id,
                    CartId = this.ShoppingCartId,
                    Count = count
                };

                this.data.ShoppingCarts.Add(cartItem);
            }
            else
            {
                cartItem.Count += count;
            }

            this.data.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = this.data.ShoppingCarts
                .All()
                .FirstOrDefault(cart => cart.CartId == this.ShoppingCartId && cart.RecordId == id);

            var itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    this.data.ShoppingCarts.Delete(cartItem);
                }

                this.data.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = this.data.ShoppingCarts.All().Where(
                cart => cart.CartId == this.ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                this.data.ShoppingCarts.Delete(cartItem);
            }

            this.data.SaveChanges();
        }

        public List<ShoppingCart> GetCartItems()
        {
            return this.data.ShoppingCarts.All().Where(cart => cart.CartId == this.ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            var count = this.data.ShoppingCarts
                .All()
                .Where(sc => sc.CartId == this.ShoppingCartId)
                .Select(sc => (int?)sc.Count)
                .Sum();
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            var total = this.data.ShoppingCarts
                .All()
                .Where(sc => sc.CartId == this.ShoppingCartId)
                .Select(sc => ((int?)sc.Count * sc.Product.Price))
                .Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = this.GetCartItems();

            // TODO: Create model for OrderDetails
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.Id,
                    UnitPrice = item.Product.Price,
                    Quantity = item.Count
                };

                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Product.Price);

                this.data.OrderDetails.Add(orderDetail);
            }

            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            this.data.SaveChanges();

            // Empty the shopping cart
            this.EmptyCart();

            // Return the OrderId as the confirmation number
            return order.Id;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    var tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        public ShoppingCartProvider GetCart(HttpContextBase context)
        {
            this.ShoppingCartId = this.GetCartId(context);
            return this;
        }

        public ShoppingCartProvider GetCart(Controller controller)
        {
            return this.GetCart(controller.HttpContext);
        }

        public void MigrateCart(string userName)
        {
            var shoppingCart = this.data.ShoppingCarts.All().Where(
               c => c.CartId == this.ShoppingCartId);

            foreach (var item in shoppingCart)
            {
                item.CartId = userName;
            }

            this.data.SaveChanges();
        }
    }
}
