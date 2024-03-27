using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Repository
{
    public class CategoryRepo:ICategoryRepo
    {
        private readonly FRUITABLESContext DbContext;
        public CategoryRepo(FRUITABLESContext _db)
        {
            DbContext = _db;

        }
        public static List<int> GetAllChildCategories(Category parentCategory)
        {
            List<int> allChildCategories = new List<int>();

            if (parentCategory.InverseParentCategory != null)
            {
                foreach (var childCategory in parentCategory.InverseParentCategory)
                {
                    allChildCategories.Add(childCategory.CategoryId);
                    allChildCategories.AddRange(GetAllChildCategories(childCategory));
                }
            }

            return allChildCategories;
        }

        public async Task <List<Category>> GetCategories()
        {
            return await DbContext.Categories.ToListAsync();
        }

        public List<Category> GetCategorieswithoutPArents()
        {
            return DbContext.Categories.Where(c=> c.ParentCategoryId == null).ToList();
        }
        public List<CategoryVM> GetAllCategories()
        {
            var categories = DbContext.Categories.ToList();

            var categoryVMs = categories.Select(c => CategoryVMMapper.MapToCategoryVM(c)).ToList();

            return categoryVMs;
        }

        public async Task<CategoryVM> GetCategoryById(int id)
        {
            var category = await DbContext.Categories.FindAsync(id);
            return category != null ? CategoryVMMapper.MapToCategoryVM(category) : null;
        }

        public async Task<CategoryVM> AddCategory(CategoryVM category)
        {
            var newCategory = new Category
            {
                Name = category.Name,
                IsActive = true,
                ParentCategoryId = category.ParentCategoryId
            };

            DbContext.Categories.Add(newCategory);
            await DbContext.SaveChangesAsync();

            return CategoryVMMapper.MapToCategoryVM(newCategory);
        }

        public async Task<CategoryVM> UpdateCategory(CategoryVM category)
        {
            var existingCategory = await DbContext.Categories.FindAsync(category.CategoryId);
            if (existingCategory == null)
                return null;

            existingCategory.Name = category.Name;
            existingCategory.IsActive = true;
            existingCategory.ParentCategoryId = category.ParentCategoryId;

            DbContext.Entry(existingCategory).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();

            return CategoryVMMapper.MapToCategoryVM(existingCategory);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await DbContext.Categories.FindAsync(id);
            if (category == null)
                return false;
            category.IsActive = false;
            //DbContext.Categories.Remove(category);
            await DbContext.SaveChangesAsync();

            return true;
        }


    }
}
