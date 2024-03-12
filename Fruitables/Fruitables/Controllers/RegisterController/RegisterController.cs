using Microsoft.AspNetCore.Mvc;

namespace Fruitables.Controllers.RegisterController
{
    public class RegisterController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
