using Microsoft.AspNetCore.Mvc;

namespace Fruitables.Controllers.ProfileController
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
