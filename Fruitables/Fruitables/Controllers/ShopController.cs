﻿using Microsoft.AspNetCore.Mvc;

namespace Fruitables.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Shop()
        {
            return View();
        }

		public IActionResult ShopDetails()
		{
			return View();
		}
	}
}