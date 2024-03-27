using FruitablesBL.EntityManagement.Interface;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables.Controllers.DashboardController
{
    public class DashboardController : Controller
    {
        private readonly IDashboardrepo Dashrepo;
        private readonly FRUITABLESContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(IDashboardrepo _dashboard, FRUITABLESContext ctx, UserManager<IdentityUser> userManager)

        {
            Dashrepo = _dashboard;
            _context = ctx;
            _userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {

            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);



            if (user != null)
            {
                var cuuuser = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(cuuuser);
                if (roles != null)
                {
                    ViewBag.role = roles;
                }
                var userId = user.UserId;
                if (roles != null && roles.Contains("Admin"))
                {
                    userId = 0;
                }
                var results = Dashrepo.GetAllSalesData(userId);

                return View(results);
            }
            return RedirectToAction("Login", "Account", null);

        }
        [HttpGet]
        public async Task<IActionResult> GetMonthSalesData(int year)
        {

            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user != null)
            {
                var cuuuser = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(cuuuser);

                var userId = user.UserId;
                if (roles != null && roles.Contains("Admin"))
                {
                    userId = 0;
                }
                var results = Dashrepo.GetMonthSalesDAta(year, userId);
                return Ok(results);
            }
            else
            {
                return BadRequest("No Loged User");
            }

        }


        public async Task<IActionResult> bestSelling(int year)

        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user != null)
            {
                var cuuuser = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(cuuuser);

                var userId = user.UserId;
                if (roles != null && roles.Contains("Admin"))
                {
                    userId = 0;
                }
                return View(Dashrepo.GetBestSellingData(year, userId));
            }
            else
            {
                return NotFound();
            }
        }


        public IActionResult bestSellers(int year)
        {
           
            return  View(Dashrepo.GetbestSelers(year));

        }


    }
}
