using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.EntityManagement.Repository;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Fruitables.Controllers.SellerController
{
    public class SellersController : Controller
    {

        private readonly ISellerRepo seller;
        public SellersController(ISellerRepo _sel)
        {
            seller = _sel;

        }
        // GET: SellerController
        public ActionResult Sellers(int pageNumber = 1)
        {
            return View(seller.getALlshops(pageNumber));
        }

        // GET: SellerController/Details/5
        public ActionResult Products(int id)
        {
            return View();
        }

        // GET: SellerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SellerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SellerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SellerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SellerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


      
    }
}
