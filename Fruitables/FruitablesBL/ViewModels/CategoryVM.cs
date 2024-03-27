using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? ParentCategoryId { get; set; }
        public List<CategoryVM>? SubCategories { get; set; } = new List<CategoryVM>();
    }
}
