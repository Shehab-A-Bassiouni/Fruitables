using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FruitablesSellers.Controllers.CategoryController
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        // GET: Category
        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepo.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryVM category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepo.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int categoryId)
        {
            var category = await _categoryRepo.GetCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int categoryId, CategoryVM category)
        {
            if (categoryId != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _categoryRepo.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int categoryId)
        {
            var category = await _categoryRepo.GetCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int categoryId)
        {
            var result = await _categoryRepo.DeleteCategory(categoryId);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

    }
}
