using FruitablesBL.EntityManagement.Interface;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fruitables.Controllers.FeedbackController
{
    public class FeedbackController : Controller
    {
        public IFeedBackRepo FeedBackRepo {  get; set; }
        public FeedbackController(IFeedBackRepo feedBackRepo)
        {
            FeedBackRepo = feedBackRepo;
        }

        // GET: FeedbackController
        [Route("Feedback/Index/{productID}")]
        public ActionResult Index(int Rate = 0, int productID = 0)
        {
            var UserName = User.Identity?.Name ?? "NotFound";
            ViewBag.CurrentCustomerId = FeedBackRepo.GetUserId(UserName);
            ViewBag.CurrentProdId = productID;

            var FilteredByRate = FeedBackRepo.GetFeedbackByRate(productID, Rate);

            if(FilteredByRate.Count != 0)
            {
                return View(FilteredByRate);
            }
            else 
                return View(FeedBackRepo.GetAllFeedbacks(productID));
        }

        // GET: FeedbackController/Details/5
        public ActionResult Details(int id)
        {
            return View(FeedBackRepo.GetFeedbackById(id));
        }

        // GET: FeedbackController/Create
        public ActionResult Create(int id)
        {
            var UserName = User.Identity?.Name??"NotFound";
            ViewBag.CustomerId = FeedBackRepo.GetUserId(UserName);
            ViewBag.ProductId = id;
            return View();
        }

        // POST: FeedbackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Feedback/Create/{ProdId}")]
        public ActionResult Create(int ProdId ,FeedBack feedback)
        {       
                feedback.ProductId = ProdId;
                if(ModelState.IsValid)
                {
                    try
                    {
                        FeedBackRepo.CreateFeedback(feedback);
                        return RedirectToAction("Index", "Feedback", new { Id = feedback.ProductId });
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                        return View(feedback);
                    }
                }
            return View(feedback);
        }

        // GET: FeedbackController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(FeedBackRepo.GetFeedbackById(id));
        }

        // POST: FeedbackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FeedBack feedback)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    FeedBackRepo.EditFeedback(feedback);
                    return RedirectToAction("Index", "Feedback", new { Id = feedback.ProductId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(feedback);
                }
            }
            return View(feedback);
        }


        [HttpGet]
        public ActionResult Delete()
        {
            return View();

        }
        // GET: FeedbackController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var ProdId = FeedBackRepo.GetFeedbackById(id).ProductId;
            FeedBackRepo.DeleteFeedback(id);
            return RedirectToAction("Index", "Feedback",new{ id = ProdId });
        }
    }
}
