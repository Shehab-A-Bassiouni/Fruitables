using Fruitables.Models.CartModel;
using Fruitables.Models.Checkout;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Stripe;
using Stripe.Checkout;

namespace Fruitables.Controllers.CheckoutController
{
    public class CheckoutController : Controller
    {
        private readonly IMemoryCache memoryCache;
        private readonly FRUITABLESContext context;
        private CheckoutModel checkoutModel;
        private IdentityUser User;
        private string UserName;
        private int UserID;
        private CartModel cartModel;
        private decimal SubTotal;
        

        public CheckoutController(IMemoryCache _memoryCache,FRUITABLESContext _context)
        {
            memoryCache = _memoryCache;
            context = _context;
            User = Global.Global.User;
            UserName = User.UserName;
            UserID = context.Users.Where(u => u.UserName == UserName).Select(id => id.UserId ).FirstOrDefault();
            checkoutModel = new(memoryCache, context, UserID);
            cartModel = new(memoryCache, context, UserID);
        }

        public ActionResult Checkout()
        {
            
            SubTotal = checkoutModel.GetSubTotal();
            return View(SubTotal);
        }

        [HttpPost]
        public ActionResult PaymentMethod( string payMethod) {
            if (payMethod == "Cod")
                return RedirectToAction("Cod");

            else
                return RedirectToAction("Card");
        }

        public ActionResult Cod()
        {
            return RedirectToAction("OrderPlaced");
        }

        public ActionResult Card()
        {
            var domain = "http://localhost:51002/";
            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + "Checkout/SuccessPayment",
                CancelUrl = domain + "Checkout/FailedPayment",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                CustomerEmail = Global.Global.User.Email
            };

            //_memoryCache.Get<CartVm>("Cart_9");
            CartVm cartItems = cartModel.GetCart();


            foreach (var item in cartItems.CartItems)
            {
                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)((item.ItemPrice-(item.ItemPrice*(item.Offer/100)))*100),
                        
                        Currency = "egp",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.ItemName,
                        },

                    },
                    Quantity = item.ItemQuantity
                };
                options.LineItems.Add(sessionListItem);
            }

            var sessionListItem2 = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)50*100,

                    Currency = "egp",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = "Shipping Fees",
                    },

                },
                Quantity = 1
            };

            options.LineItems.Add(sessionListItem2);

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        
    
        public ActionResult SuccessPayment() {
            cartModel.CreateOrder(SubTotal);
            
            return View();
        }

        public ActionResult FailedPayment()
        {
            return View();
        }
        
        public ActionResult OrderPlaced()
        {
            cartModel.CreateOrder(SubTotal);
            return View();
        }


    }
}
