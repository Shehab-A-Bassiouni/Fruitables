using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.EntityManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;

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
        [Route("Sellers")]
        public ActionResult Sellers(string sName, int pageNumber = 1)
        {

            
            if (sName != null)
            {
                ViewBag.sNAme = sName;  
                return View(seller.getShopsbyName(sName, pageNumber));
            }


            else
            {
                return View(seller.getALlshops(pageNumber));
            }
        }

        // GET: SellerController/Details/5
       
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
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


      
    }
}
