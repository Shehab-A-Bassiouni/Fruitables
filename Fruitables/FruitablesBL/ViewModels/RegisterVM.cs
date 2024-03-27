using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string UserName {  get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This Must Match the Password Field")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password is not a Match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Mobile Number Must be 11 digits only")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please Choose your Role")]
        [Display(Name = "User Type")]
        public UserType UserType { get; set; }

        public bool RememberMe { get; set; }
    }

    public enum UserType
    {
        Admin, Seller, Customer
    }
}
