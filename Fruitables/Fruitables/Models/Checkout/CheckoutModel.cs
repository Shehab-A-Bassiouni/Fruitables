using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using System.Security.AccessControl;

namespace Fruitables.Models.Checkout
{
    public class CheckoutModel
    {

        private readonly IMemoryCache _memoryCache;
        private readonly FRUITABLESContext context;
        private int UserID;


        public CheckoutModel(IMemoryCache memoryCache , FRUITABLESContext _context , int _UserID) {
            _memoryCache = memoryCache;
            context = _context;
            UserID = _UserID;
        }

        public decimal GetSubTotal() {
            string key = $"Cart_{UserID}";
            decimal subTotal = 0;
            if (_memoryCache.TryGetValue(key, out CartVm cart))
            {
                foreach (CartItemVM item in cart.CartItems) {
                    subTotal += item.ItemTotalPrice;
                }
            }
            return subTotal;
        }
    }
}
