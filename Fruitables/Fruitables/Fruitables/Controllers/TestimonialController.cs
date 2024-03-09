using Microsoft.AspNetCore.Mvc;

namespace Fruitables.Controllers
{
    public class TestimonialController : Controller
    {
        public IActionResult Testimonial()
        {
            return View();
        }
    }
}
