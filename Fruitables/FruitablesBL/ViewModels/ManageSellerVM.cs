using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{
    public class ManageSellerVM
    {
        public int Id { get; set; }

        public int SellerId { get; set; }
        public string SellerName { get; set; }
        [Required(ErrorMessage ="Please Enter Name Of Shop")]
        public string CommercialName { get; set; }

        public decimal Rate { get; set; }
        [Required(ErrorMessage ="Please Enter Address here")]
        public string Address { get; set; }

        
        public string? Logo { get; set; }

        public virtual ICollection<Product>? Products { get; set; } = new List<Product>();

    }
}
