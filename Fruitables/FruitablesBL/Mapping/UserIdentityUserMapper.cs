using FruitablesDAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class UserIdentityUserMapper
    {
        public static User IdentityUserToUser (IdentityUser identityUser)
        {
            User newUser = new User();

            newUser.UserName = identityUser.UserName;
            newUser.Email = identityUser.Email;
            newUser.PhoneNumber = identityUser.PhoneNumber;
            newUser.Password = identityUser.PasswordHash;
            newUser.IsActive = true;
            newUser.Image = "avatar.jpg";
            newUser.FirstName = "Unknown";
            newUser.LastName = "Unknown";

            return newUser;
        }

        public static Customer IdentityUserToCustomer (User user)
        {
            Customer customer = new Customer();

            customer.CustomerId = user.UserId;
            customer.Address = "Unknown";

            return customer;
        }

        public static Seller IdentityUserToSeller(User user)
        {
            Seller seller = new Seller();

            seller.SellerId = user.UserId;
            seller.Address = "Unknown";
            seller.Rate = 0;
            seller.Logo = "avatar.jpg";
            seller.CommercialName = "Unknown";

            return seller;
        }

        public static Admin IdentityUserToAdmin(User user)
        {
            Admin admin = new Admin();

            admin.AdminId = user.UserId;
            admin.AuthorityLevelId = 0;

            return admin;
        }

    }
}
