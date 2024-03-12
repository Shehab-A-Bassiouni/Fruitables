using FruitablesBL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Diagnostics;

namespace Fruitables.Controllers.CartController
{
    public class CartController : Controller
    {

        public ActionResult Cart()
        {
            return RedirectToAction("EmptyCart");
        }
        public ActionResult EmptyCart()
        {
            return View();
        }

      

    }
}
