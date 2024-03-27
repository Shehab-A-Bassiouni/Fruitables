using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{
    public class OffersVM
    {

        public int OfferId { get; set; }
        
         [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
       
        [Required(ErrorMessage = "Discount is required")]
        [Range(0, 99, ErrorMessage = "Rate must be between 0 and 99")]
        public decimal Discount { get; set; }

        [Required(ErrorMessage = "Expiration date is required")]   
        public DateTime ExpireDate { get; set; }


    }
}
