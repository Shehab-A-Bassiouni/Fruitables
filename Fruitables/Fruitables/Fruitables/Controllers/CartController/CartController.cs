using Fruitables.Models.Cart;
using FruitablesBL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fruitables.Controllers.CartController
{
    public class CartController : Controller
    {


        [HttpGet]
        [HttpPost]
        public ActionResult Cart([FromBody] List<string>? data = null)
        {
            if (data == null)
            {
                return View(new List<int>());
            }

            List<int> items = data.Select(str => int.TryParse(str, out int result) ? result : 0).ToList();

            return View("Cart",items);
        }

    }
}
