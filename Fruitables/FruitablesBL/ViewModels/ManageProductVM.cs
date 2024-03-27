using FruitablesDAL.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FruitablesBL.ViewModels
{
    public class ManageProductVM
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative value")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Rate is required")]
        [Range(0, 5, ErrorMessage = "Rate must be between 0 and 5")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "CostPrice is required")]
        [Range(0, double.MaxValue, ErrorMessage = "CostPrice must be a positive value")]
        public decimal CostPrice { get; set; }

        [Required(ErrorMessage = "CategoryId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be a positive value")]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public int IsActive { get; set; }


        [Required(ErrorMessage = "SellerId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "SellerId must be a positive value")]
        public int SellerId { get; set; }

        [ValidateNever]
        public string Image { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
        //public virtual Seller? Seller { get; set; }
        public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

        // Additional properties to hold dropdown data
        public IEnumerable<SelectListItem> Sellers { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
