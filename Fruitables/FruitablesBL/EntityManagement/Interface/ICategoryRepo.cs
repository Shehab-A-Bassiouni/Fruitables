using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Interface
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetCategories();
        List<Category> GetCategorieswithoutPArents();

        public List<CategoryVM> GetAllCategories();

        Task<CategoryVM> GetCategoryById(int id);
        Task<CategoryVM> AddCategory(CategoryVM category);
        Task<CategoryVM> UpdateCategory(CategoryVM category);
        Task<bool> DeleteCategory(int id);
    }
}
