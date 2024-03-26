using FruitablesBL.EntityManagement.Repository;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Fruitables.Models.CartModel
{
    public class CartModel
    {
        private readonly IMemoryCache memoryCache;
        private readonly FRUITABLESContext context;
        private int UserID;
        private string CartKey;

        public CartModel(IMemoryCache _memoryCache, FRUITABLESContext _context , int _UserID)
        {
            memoryCache = _memoryCache;
            context= _context;
            UserID = _UserID;
            CartKey = "Cart_" + UserID.ToString();
        }

        public void AddItemToCart(int itemID, string itemName, decimal itemPrice, int itemQuantity, decimal itemTotalPrice, string itemImage , decimal offer ,int productID)
        {
            CartItemVMMapper cartItemMapper = new();
            CartItemVM cartItem = cartItemMapper.SetCartItem(itemID, itemName, itemPrice, itemQuantity, itemTotalPrice, itemImage, offer , productID);

            if (memoryCache.TryGetValue(CartKey, out CartVm cachedCart))
            {
                if (cachedCart.CartItems.FirstOrDefault(x => x.ProductID == productID) != null)
                {
                    ChangeQuantity(itemID, "+");
                }
                else { 
                    cachedCart.CartItems.Add(cartItem);
                }
            }
            else
            {
                cachedCart = new CartVm
                {
                    CustomerID = UserID,
                    CartItems = new List<CartItemVM> { cartItem }
                };
            }

            memoryCache.Set(CartKey, cachedCart);
        }

        public CartVm GetCart()
        {

            if (memoryCache.TryGetValue(CartKey, out CartVm cart))
            {
                return cart!;
            }

            return new CartVm(); 
        }

        public void ChangeQuantity(int itemID,string op )
        {
           

            if (memoryCache.TryGetValue(CartKey, out CartVm cachedCart))
            {
                CartItemVM cartItem = cachedCart.CartItems.FirstOrDefault(item => item.ItemID == itemID);
                decimal price = cartItem.ItemPrice;
                int quantity = 0;
                if (op == "+")
                {
                     quantity = ++cartItem.ItemQuantity;
                    

                }
                else {
                     quantity = --cartItem.ItemQuantity;
                    if (quantity < 1) {
                        cartItem.ItemQuantity = 1;
                    }

                }
                cartItem.ItemTotalPrice = quantity * (price - (price * (cartItem.Offer / 100)));

            }

        }

        public bool DeleteItem(int itemID ) {

            if (memoryCache.TryGetValue(CartKey, out CartVm cachedCart))
            {
                CartItemVM itemObj = cachedCart.CartItems.FirstOrDefault(item => item.ItemID == itemID);
                cachedCart.CartItems.Remove(itemObj);
                return true;
            }
            return false;

        }

        public bool CreateOrder(decimal subTotal)
        {
            if (memoryCache.TryGetValue(CartKey, out CartVm cart))
            {
                Order order = new Order();
                order.State = 1;
                order.Date = DateTime.Now;
                order.ShippingAddress = context.Customers.Find(UserID).Address;
                order.TotalPrice = subTotal;
                order.IsActive = true;
                order.OrderName = "Customer Order";
                order.CustomerId = UserID;
                order.ShippingFees = 50;
                order.Voucher = 0;
                order.Items = new List<Item>();

                int orderId = 1;

                if (context.Orders.ToList().Count > 0) { 
                 orderId = context.Orders.OrderBy(x=>x.OrderId).Last().OrderId;
                }

                foreach (CartItemVM item in cart.CartItems)
                {
                    Item Singleitem = new();
                    Singleitem.Address = order.ShippingAddress;
                    Singleitem.Discount = order.Voucher;
                    Singleitem.Quantity = item.ItemQuantity;
                    Singleitem.SubTotalPrice = item.ItemTotalPrice;
                    Singleitem.MomentPrice = item.ItemTotalPrice;
                    Singleitem.IsActive = true;
                    Singleitem.OrderId = orderId;
                    Singleitem.ProductId = item.ItemID;

                    order.Items.Add( Singleitem );
                }
                context.Orders.Add( order );
                context.SaveChanges();
                memoryCache.Remove(CartKey);
                return true;
            }
            return false;

        }


    }
}
