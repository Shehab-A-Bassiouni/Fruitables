using Fruitables.Models.CartModel;
using Fruitables.Models.Orders;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Fruitables.Controllers.OrdersController
{
    public class OrdersController : Controller
    {

        private readonly IMemoryCache memoryCache;
        private readonly FRUITABLESContext context;
        private string UserName;
        private int UserID;
        private CartModel cartModel;
        private IdentityUser User;
        private OrderModel orderModel;


        public OrdersController(IMemoryCache _memoryCache, FRUITABLESContext _context)
        {
            memoryCache = _memoryCache;
            context = _context;
            User = Global.Global.User;
            if (Global.Global.User != null)
            {
                UserName = User.UserName;
                UserID = context.Users.Where(u => u.UserName == UserName).Select(id => id.UserId).FirstOrDefault();
            }
            orderModel = new(memoryCache , context , UserID);
        }

        public IActionResult Orders() { 
            
            return View();
        
        }

        [HttpGet]
        public IActionResult FinishedOrders()
        {
            if (Global.Global.User == null)
                return RedirectToAction("Register", "Account", null);
            
            return View(orderModel.GetFinishedOrders());

        }

        public IActionResult UnFinishedOrders()
        {
            if (Global.Global.User == null)
                return RedirectToAction("Register", "Account", null);

            return View(orderModel.GetNotFinishedOrders());

        }

        public IActionResult ViewUnfinished() { 
        
            return View();

        }

        public IActionResult ViewFinished() { 
        
            return View();

        }

        public IActionResult DeleteUnfinished(int orderID)
        {
          bool res =  orderModel.DeleteUnfinished(orderID);
            if (res) return RedirectToAction("UnFinishedOrders");
            return View("DeleteUnfinishedFailed");
        }

        public IActionResult OrderDetails(int orderID) { 
            List<ItemVM> items = orderModel.GetOrderItems(orderID);
            return View(items);
        }
    }
}
