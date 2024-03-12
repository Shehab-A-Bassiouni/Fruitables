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

        List<string> lst;
        [HttpPost]
        public ActionResult Cart(List<string> dataArray)
        {
            lst = dataArray;

            return Json(new { success = true, message = "Data received successfully" });
        }



        [HttpGet]
        public ActionResult Cart()
        {
            if (lst is null) {
                lst = new() { "1" };
            }
            return View(lst);
        }



    }
}
