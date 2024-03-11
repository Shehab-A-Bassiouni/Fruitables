using Fruitables.Models.Cart;
using FruitablesBL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fruitables.Controllers.CartController
{
    public class CartController : Controller
    {
        // GET: CartController
        public ActionResult Cart()
        {
          
            return View();
        }

   
    }
}
