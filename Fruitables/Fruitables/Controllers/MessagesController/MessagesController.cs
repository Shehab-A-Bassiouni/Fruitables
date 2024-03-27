using Microsoft.AspNetCore.Mvc;

namespace Fruitables.Controllers.MessagesController
{
    public class MessagesController : Controller
    {
        public IActionResult Messages()
        {
            return View();
        }

        public IActionResult MessageDelete() {
            return RedirectToAction("Messages");
        
        }
    }
}
