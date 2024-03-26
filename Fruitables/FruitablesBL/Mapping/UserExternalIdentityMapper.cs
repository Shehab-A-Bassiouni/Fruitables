using FruitablesDAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class UserExternalIdentityMapper
    {
        public static User ExternalUserToUser(IdentityUser identityUser)
        {
            User newUser = new User();

            newUser.UserName = identityUser.UserName;
            newUser.Email = identityUser.Email;
            newUser.IsActive = true;
            newUser.Image = "avatar.jpg";
            newUser.FirstName = "Unknown";
            newUser.LastName = "Unknown";
            newUser.PhoneNumber = "0000000000";

            return newUser;
        }

        public static Customer IdentityUserToCustomer(User user)
        {
            Customer customer = new Customer();

            customer.CustomerId = user.UserId;
            customer.Address = "Unknown";

            return customer;
        }
    }
}
