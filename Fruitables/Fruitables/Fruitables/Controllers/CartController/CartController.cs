using Fruitables.Models.Cart;
using FruitablesBL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fruitables.Controllers.CartController
{
    public class CartController : Controller
    {
       

        [HttpPost]
        public ActionResult Cart(string data)
        {
            
            return View(data);
        }


    }
}
