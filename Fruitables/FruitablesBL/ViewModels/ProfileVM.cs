using FruitablesDAL.Models;
using System.ComponentModel.DataAnnotations;

namespace FruitablesBL.ViewModels
{
    public class ProfileVM
    {
        public int UserId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Mobile Number Must be 11 digits only")]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string? OldPassword { get; set; }


        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }
        public Admin? Admin { get; set; }
        public Customer? Customer { get; set; }
        public Seller? Seller { get; set; }
        // Additional properties for specific user types
        // For example, properties for Customer
        public string? Image { get; set; }

        public int? CustomerId { get; set; }
        public string? Address { get; set; }
        // Properties for Seller
        public int? SellerId { get; set; }
        public string? CommercialName { get; set; }
        public decimal? Rate { get; set; }
        public string? Logo { get; set; }
        public string? AddressSeller { get; set; }
        // Properties for Admin
        public int? AdminId { get; set; }
        public int? AuthorityLevelId { get; set; }

    }
}
