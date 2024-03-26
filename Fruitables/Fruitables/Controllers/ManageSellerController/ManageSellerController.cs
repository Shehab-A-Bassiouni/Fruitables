using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.ViewModels;
using FruitlessBL.EntityManagement.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FruitablesSellers.Controllers.ManageSellerController
{
    public class ManageSellerController : Controller
    {
        public readonly IManageSellerRepo manageSellerRepo;
        public readonly ISellerRepo seller;

        public ManageSellerController(IManageSellerRepo _manageSellerRepo,ISellerRepo _seller)
        {
            manageSellerRepo = _manageSellerRepo;
            seller= _seller;
        }
        // GET: ManageSellerController
        public IActionResult GetAll()
        
        {
            

            return View(manageSellerRepo.GetALlSeller());
        }

        // GET: ManageSellerController/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("GetAll");
            }
            return View(manageSellerRepo.GetSellerById(id));
        }


    }
}
