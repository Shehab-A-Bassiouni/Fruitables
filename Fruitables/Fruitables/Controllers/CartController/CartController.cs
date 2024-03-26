using Fruitables.Models.CartModel;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.AspNetCore.Identity.IdentityUser;
using Fruitables.Global;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fruitables.Controllers.CartController
{
    public class CartController : Controller
    {

        private readonly IMemoryCache memoryCache;
        private readonly FRUITABLESContext context;
        private string UserName;
        private int UserID;
        private CartModel cartModel;
        private IdentityUser User;


        public CartController(IMemoryCache _memoryCache, FRUITABLESContext _context )
        {
            memoryCache = _memoryCache;
            context = _context;
            User = Global.Global.User;
            if (Global.Global.User != null) {  
            UserName = User.UserName;
            UserID=context.Users.Where(u => u.UserName == UserName).Select(id=> id.UserId).FirstOrDefault();
            cartModel = new(memoryCache, context, UserID);
            }
        }

  

        [HttpGet]
        public ActionResult Cart() {
            if(Global.Global.User == null)
                return RedirectToAction("Register", "Account", null);
            CartVm cartItems = cartModel.GetCart();
            return View(cartItems);

        }

        [HttpPost]
        public ActionResult Cart(int itemID, string itemName, decimal itemPrice, int itemQuantity, decimal itemTotalPrice ,string itemImage , decimal offer)
        {
            if (Global.Global.User == null)
                return RedirectToAction("Register", "Account", null);
            cartModel.AddItemToCart( itemID,  itemName,  itemPrice,  itemQuantity,  itemTotalPrice,  itemImage,  offer , itemID);
            return NoContent();
        }


        [HttpPost]
        public ActionResult QuantityChange([FromBody] QuantityChangeRequest request)
        {
            int itemID = request.ItemID;
            string op = request.Op;

            cartModel.ChangeQuantity(itemID, op);

            memoryCache.TryGetValue($"Cart_{UserID.ToString()}", out CartVm cart);

            int _NewQuantity = cart.CartItems.FirstOrDefault(item => item.ItemID == itemID).ItemQuantity;
            decimal _NewTotal= cart.CartItems.FirstOrDefault(item => item.ItemID == itemID).ItemTotalPrice; ;


            var responseData = new
            {
                NewQuantity = _NewQuantity,
                NewTotal = _NewTotal
            };

            return Json(responseData);
        }


        public ActionResult DeleteItem(int itemID) {
            cartModel.DeleteItem(itemID);
            return RedirectToAction("Cart");
        }

        public ActionResult GoCheckout() { 
            return RedirectToAction("Checkout", "Checkout" );
        }


    }

 

    public class QuantityChangeRequest
    {
        public int ItemID { get; set; }
        public string Op { get; set; }
    }

  
}
