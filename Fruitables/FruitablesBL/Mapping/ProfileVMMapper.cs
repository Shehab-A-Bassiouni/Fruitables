using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using System.Diagnostics;

namespace FruitablesBL.Mapping
{
    public class ProfileVMMapper
    {
        public ProfileVM? profileMap(User user, Customer customer, Seller seller, Admin admin)
        {
            try
            {
                ProfileVM profileVM = new ProfileVM
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Customer = user.Customer,
                    Admin = user.Admin,
                    Seller = user.Seller,
                    CurrentPassword = user.Password,
                    Image = user.Image,
                };

                if (customer != null && user.UserId == user.Customer.CustomerId)
                {
                    // User is a Customer
                    profileVM.Address = user.Customer.Address;
                }
                else if (seller != null && user.UserId == user.Seller.SellerId)
                {
                    // User is a Seller
                    profileVM.CommercialName = user.Seller.CommercialName;
                    profileVM.Rate = user.Seller.Rate;
                    //profileVM.Logo = user.Seller.Logo;
                }
                else if (admin != null && user.UserId == user.Admin.AdminId)
                {
                    // User is an Admin
                    profileVM.AuthorityLevelId = user.Admin.AuthorityLevelId;
                }


                return profileVM;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public List<object>? MapToEntities(ProfileVM profile, FRUITABLESContext dbContext)
        {
            var mappedEntities = new List<object>();

            try
            {
                // Fetch the user entity
                var userEntity = dbContext.Users.FirstOrDefault(u => u.UserId == profile.UserId);

                if (userEntity != null)
                {
                    // Update properties of the userEntity with values from profileVM
                    userEntity.FirstName = profile.FirstName;
                    userEntity.LastName = profile.LastName;
                    userEntity.UserName = profile.UserName;
                    userEntity.PhoneNumber = profile.PhoneNumber;
                    userEntity.Email = profile.Email;
                    userEntity.Password = profile.CurrentPassword;
                    userEntity.Customer = profile.Customer;
                    userEntity.Seller = profile.Seller;
                    userEntity.Admin = profile.Admin;
                    userEntity.Image = profile.Image;
                    // Add the userEntity to the list of mapped entities
                    mappedEntities.Add(userEntity);

                    // Update Customer entity if available
                    if (profile.Customer != null)
                    {
                        var customerEntity = dbContext.Customers.FirstOrDefault(c => c.CustomerId == profile.Customer.CustomerId);
                        if (customerEntity != null)
                        {
                            customerEntity.Address = profile.Customer.Address;
                            // Add the customerEntity to the list of mapped entities
                            mappedEntities.Add(customerEntity);
                        }
                    }

                    // Update Seller entity if available
                    if (profile.Seller != null)
                    {
                        var sellerEntity = dbContext.Sellers.FirstOrDefault(s => s.SellerId == profile.Seller.SellerId);
                        if (sellerEntity != null)
                        {
                            sellerEntity.CommercialName = profile.Seller.CommercialName;

                            // Check if profile.Rate is not null before assigning its value
                            if (profile.Rate.HasValue)
                            {
                                // Assign profile.Rate.Value to sellerEntity.Rate if profile.Rate is not null
                                sellerEntity.Rate = profile.Rate.Value;
                            }
                            sellerEntity.Logo = profile.Seller.Logo;
                            sellerEntity.Address = profile.Seller.Address;
                            // Add the sellerEntity to the list of mapped entities
                            mappedEntities.Add(sellerEntity);
                        }
                    }


                    // Update Admin entity if available
                    if (profile.Admin != null)
                    {
                        var adminEntity = dbContext.Admins.FirstOrDefault(a => a.AdminId == profile.Admin.AdminId);
                        if (adminEntity != null)
                        {
                            // Check if AuthorityLevelId is not null in the ProfileVM
                            if (profile.AuthorityLevelId.HasValue)
                            {
                                // Assign the value from ProfileVM to AuthorityLevelId
                                adminEntity.AuthorityLevelId = profile.Admin.AuthorityLevelId;
                                // Add the adminEntity to the list of mapped entities
                                mappedEntities.Add(adminEntity);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error mapping ProfileVM to entities: {ex.Message}");
                // Optionally, handle the exception
                return null;
            }

            return mappedEntities;
        }


    }
}
