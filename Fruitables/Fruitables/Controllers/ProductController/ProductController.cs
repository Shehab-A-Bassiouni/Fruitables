using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;

namespace Fruitables.Controllers.ProductController
{
    public class ProductController : Controller
    {

        private readonly IproductRepo product;
        private readonly ICategoryRepo category;
        


        public ProductController(IproductRepo prd, ICategoryRepo categ)
        {
            product = prd;
            category = categ;
          

        }
        // GET: ProductController
        public ActionResult Products(string pName, int categID, int sellerID, decimal filterPrice = 0, int pageNumber = 1)
        {

            ViewBag.MainCategories = category.GetCategorieswithoutPArents();
            if (pName != null)
            {
                ViewBag.pName = pName;
            }
            if (sellerID > 0)
            {
                ViewBag.sellerID = sellerID;
            }

            return View(product.GetProducts(categID, sellerID, filterPrice, pName, pageNumber));
        }


        public ActionResult Productfilter(string pName, int categID, int sellerID, decimal filterPrice = 0, int pageNumber = 1)
        {

            ViewBag.MainCategories = category.GetCategorieswithoutPArents();
            if (pName != null)
            {
                ViewBag.pName = pName;
            }
            if (sellerID > 0)
            {
                ViewBag.sellerID = sellerID;
            }

            return PartialView("productList", product.GetProducts(categID, sellerID, filterPrice, pName, pageNumber));
        }


        public ActionResult Pagination(string pName, int categID, int sellerID, decimal filterPrice = 0, int pageNumber = 1)
        {

            ViewBag.MainCategories = category.GetCategorieswithoutPArents();
            if (pName != null)
            {
                ViewBag.pName = pName;
            }
            if (sellerID > 0)
            {
                ViewBag.sellerID = sellerID;
            }

            return PartialView("productList2", product.GetProducts(categID, sellerID, filterPrice, pName, pageNumber));
        }





        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Products");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Products");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Products");
            }
            catch
            {
                return View();
            }
        }
    }
}
