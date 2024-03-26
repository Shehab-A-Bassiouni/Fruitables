using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FruitablesBL.EntityManagement.Repository
{
    public class ProfileRepo : InterProfileRepo
    {
        private  FRUITABLESContext DbContext;
        private readonly ProfileVMMapper _profileMapper;

        public ProfileRepo(FRUITABLESContext db, ProfileVMMapper profileVMMapper)
        {
            DbContext = db;
            _profileMapper = profileVMMapper;
        }
        public ProfileVM GetProfile(int userId)
        {
            // Assuming there is a DbSet<ProfileEntity> in your DbContext
            var profileEntity = DbContext.Users.FirstOrDefault(p => p.UserId == userId);
            Customer? profileEntityForCustomer = DbContext.Customers.FirstOrDefault(p => p.CustomerId == userId);
            Seller? profileEntityForSeller = DbContext.Sellers.FirstOrDefault(p => p.SellerId == userId);
            Admin? profileEntityForAdmin = DbContext.Admins.FirstOrDefault(p => p.AdminId == userId);

            if (profileEntity != null)
            {
                // Optionally, you can use a mapper to map from entity to domain model
                var profileMapper = new ProfileVMMapper();
                    return profileMapper.profileMap(profileEntity, profileEntityForCustomer, profileEntityForSeller, profileEntityForAdmin);

            }

                // Handle the case when the profile is not found (return null, throw an exception, etc.)
                return null;
        }

        public async void UpdateProfile(ProfileVM profile )
        {
            var profileEntity = DbContext.Users.FirstOrDefault(p => p.UserId == profile.UserId);

            try
            {
                var mappedEntities = _profileMapper.MapToEntities(profile, DbContext);
                

                if (mappedEntities != null)
                {
                    foreach (var entity in mappedEntities)
                    {
                        DbContext.Update(entity);
                    }

                    DbContext.SaveChanges();
                    Console.WriteLine("Update Done");
                }
                else
                {
                    Console.WriteLine("No entities mapped for the given profile");
                }
            }
            catch (DbUpdateException ex)
            {
                // Log the outer exception
                Console.WriteLine($"DbUpdateException occurred: {ex.Message}");

                // Retrieve the inner exception
                Exception innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine($"Inner Exception: {innerException.Message}");
                    innerException = innerException.InnerException;
                }

                // Optionally, handle the exception differently based on the inner exception details
                throw; // Rethrow the exception or handle it accordingly
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An error occurred while updating profile: {ex.Message}");
                // Optionally, rethrow the exception or handle it accordingly
            }
        }

       
    }
}
