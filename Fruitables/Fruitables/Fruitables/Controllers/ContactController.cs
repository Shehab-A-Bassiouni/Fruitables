﻿using Microsoft.AspNetCore.Mvc;

namespace Fruitables.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
