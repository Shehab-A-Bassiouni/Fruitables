using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Fruitables.Controllers.Offer
{
    public class DashboardOfferController : Controller
    {
        private readonly IOfferRepo offerRepo;
        private readonly FRUITABLESContext _context;
        public DashboardOfferController(IOfferRepo _offerRepo, FRUITABLESContext ctx)

        {
            offerRepo = _offerRepo;
            _context = ctx;

        }
        // GET: OfferController
        
        public async Task<ActionResult> Index()
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user != null)
            {
                return View(await offerRepo.GetAllOffrs(user.UserId));
            }
            else
            {
                return View(await offerRepo.GetAllOffrs(0));
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            return View(await offerRepo.GetOffer(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(OffersVM offerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                    if (user != null)
                    {
                        OffersVM offervm = await offerRepo.CeateOffer(offerVM, user.UserId);
                        return View("Details", offervm);

                    }

                }
                return View("Create", offerVM);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return View(offerVM);
            }
        }

       

        // POST: OfferController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(OffersVM offerVM)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    OffersVM offervm =  await offerRepo.Edit(offerVM);
                    return View("Details", offervm);
                }
                return View("Details", offerVM);

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return View("Details", offerVM);
            }
        }

        // GET: OfferController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user != null)
            {
                await offerRepo.Delete(id);
                return View("Index", await offerRepo.GetAllOffrs(user.UserId));
            }
            else
            {
                return View("Index");
            }
               
        }

        // POST: OfferController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
