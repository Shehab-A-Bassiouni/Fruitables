using Microsoft.AspNetCore.Mvc;

namespace Fruitables.Controllers
{
    public class ContactController : Controller
    {
        //Comment
        public IActionResult Contact()
        {
            return View();
        }
    }
}
