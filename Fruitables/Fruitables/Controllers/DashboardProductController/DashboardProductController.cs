using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.EntityManagement.Repository;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FruitablesSellers.Controllers.ProductController
{
    public class DashboardProductController : Controller
    {
        private readonly IproductRepo _productRepo;
        private readonly ISellerRepo _sellerRepo; // Assuming you have a SellerRepo
        private readonly ICategoryRepo _categoryRepo; // Assuming you have a CategoryRepo
        IWebHostEnvironment _webHostEnvironment;
        public FRUITABLESContext Context { get; set; }


        public DashboardProductController(IproductRepo productRepo, ISellerRepo sellerRepo, ICategoryRepo categoryRepo, IWebHostEnvironment webHostEnvironment, FRUITABLESContext context)
        {
            _productRepo = productRepo;
            _sellerRepo = sellerRepo;
            _categoryRepo = categoryRepo;
            _webHostEnvironment = webHostEnvironment;
            Context = context;
        }
        public IActionResult Index()
        {
            var sellerid = Context.Users.Where(U => U.UserName == User.Identity.Name).Select(U => U.UserId).FirstOrDefault();

           
            var products = _productRepo.GetAllProducts(sellerid);
            return View("Index", products);
            

        }

        // GET: Product/Create
        public IActionResult Create()
        {
            var sellerid = Context.Users.Where(U => U.UserName == User.Identity.Name).Select(U => U.UserId).FirstOrDefault();

            var categories = _categoryRepo.GetAllCategories();

            var model = new ManageProductVM
            {
                Categories = categories.Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name }),
                SellerId = sellerid 
            };

            return View("Create", model);
            
        }

        // POST: Product/Create
        [HttpPost]

        public IActionResult Create(ManageProductVM model, IFormFile? imageFormFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFormFile != null)
                {
                    string imgExtension = Path.GetExtension(imageFormFile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgPath = "\\images\\" + imgName;
                    model.Image = imgPath;
                    string imgFullPath = _webHostEnvironment.WebRootPath + imgPath;

                    FileStream imgFileStream = new FileStream(imgFullPath, FileMode.Create);
                    imageFormFile.CopyTo(imgFileStream);
                    imgFileStream.Dispose();
                }
                else
                {
                    model.Image = "\\images\\No_image_available.svg.png";

                }
                // Model is valid, proceed with creating the product
                _productRepo.CreateProduct(model);

                // Redirect to a success page or any other action
                return RedirectToAction("Index", model);
            }
            return View("Index", model);
            
        }

        public IActionResult ProductDetails(int productId)
        {
            var model = _productRepo.GetProductById(productId);
            return View("ProductDetails", model);
        }
        // GET: Product/Delete/{productId}
        public IActionResult Delete(int productId)
        {
            var product = _productRepo.GetProductById(productId);
            if (product == null)
            {
                return NotFound(); 
            }

            return View("Delete", product);
        }

        // POST: Product/Delete/{productId}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int productId)
        {
            // Ensure the product exists before attempting deletion
            var product = _productRepo.GetProductById(productId);

            if (product != null && product.Image != "\\images\\No_image_available.svg.png")
            {
                string imgFullPath = _webHostEnvironment.WebRootPath + product.Image;
                System.IO.File.Delete(imgFullPath);
            }

            _productRepo.DeleteProduct(productId);
            return RedirectToAction("index"); // Redirect to product list after successful deletion
        }

        // GET: Product/Edit/{id}
        public IActionResult Edit(int productId)
        {
            var model = _productRepo.GetProductForEdit(productId);

            if (model == null)
            {
                return NotFound(); // Handle case where product is not found
            }

            return View("Edit", model);
        }

        // POST: Product/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int productId, ManageProductVM model, IFormFile? imageFormFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFormFile != null)
                {
                    if (model.Image != "\\images\\No_image_available.svg.png")
                    {
                        string oldImgFullPath = _webHostEnvironment.WebRootPath + model.Image;
                        System.IO.File.Delete(oldImgFullPath);
                    }

                    string imgExtension = Path.GetExtension(imageFormFile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgPath = "\\images\\" + imgName;
                    model.Image = imgPath;
                    string imgFullPath = _webHostEnvironment.WebRootPath + imgPath;

                    FileStream imgFileStream = new FileStream(imgFullPath, FileMode.Create);
                    imageFormFile.CopyTo(imgFileStream);
                    imgFileStream.Dispose();
                }
                _productRepo.UpdateProduct(model);
                return RedirectToAction("Index", model);
            }
            return View(model);
        }

    }
}

