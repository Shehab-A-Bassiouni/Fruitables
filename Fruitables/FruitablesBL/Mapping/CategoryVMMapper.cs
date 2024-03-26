using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class CategoryVMMapper
    {
        public static CategoryVM MapToCategoryVM(Category category)
        {
            if (category == null)
                return null;

            return new CategoryVM
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                IsActive = category.IsActive,
                ParentCategoryId = category.ParentCategoryId
            };
        }
    }
}
