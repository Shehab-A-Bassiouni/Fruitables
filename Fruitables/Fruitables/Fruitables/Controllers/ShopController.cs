using Fruitables.Models.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Fruitables.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Shop()
        {
            Shop shops = new();
            return View(shops.GetShops());
        }

        public IActionResult ShopDetail()
        {
            return View();
        }
    }
}
