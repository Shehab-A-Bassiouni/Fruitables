using FruitablesBL.EntityManagement.Interface;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FruitablesSellers.Controllers.OrderController
{
    public class DashboardOrderController : Controller
    {
        private readonly IOrder orderRepo;
        public FRUITABLESContext Context { get; set; }

        public DashboardOrderController(IOrder orderRepo, FRUITABLESContext context)
        {
            this.orderRepo = orderRepo;
            Context = context;
        }

        // Action to display all orders for a seller
        public ActionResult Index()
        {
            var sellerid = Context.Users.Where(U => U.UserName == User.Identity.Name).Select(U => U.UserId).FirstOrDefault();

            var orders = orderRepo.GetAllOrdersForSeller(sellerid);
            return View("Index",orders);
        }

        // Action to update shipping state
        [HttpPost]
        public ActionResult UpdateShippingState(int orderId, bool newShippingState)
        {
            orderRepo.UpdateShippingState(orderId, newShippingState);
            return RedirectToAction("Index"); // Redirect to the index action to display updated orders
        }
    }
}
