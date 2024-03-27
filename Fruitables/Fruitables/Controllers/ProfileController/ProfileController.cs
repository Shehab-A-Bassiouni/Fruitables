
using FruitablesBL.EntityManagement.Repository;
using FruitablesBL.EntityManagement.Interface;

using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;


namespace Fruitables.Controllers
{
    public class ProfileController : Controller
    {
        private readonly InterProfileRepo _profileRepo;
        IWebHostEnvironment _webHostEnvironment;
        public FRUITABLESContext Context { get; set; }

        public UserManager<IdentityUser> UserManager { get; set; }

        public ProfileController(InterProfileRepo profileRepo , FRUITABLESContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _profileRepo = profileRepo;
            Context = context;
            UserManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public ActionResult Index(int userId)
        {
            // Use the repository to get the profile
            var CurrentID = Context.Users.Where(U => U.UserName == User.Identity.Name).Select(U=>U.UserId).FirstOrDefault();
            var profile = _profileRepo.GetProfile(CurrentID);

            // Further logic or return the profile to the view
            return View(profile);
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int userId)
        {
            var CurrentID = Context.Users.Where(U => U.UserName == User.Identity.Name).Select(U => U.UserId).FirstOrDefault();
            var profile = _profileRepo.GetProfile(CurrentID);

            if (profile != null)
            {
                return View(profile);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        
        public async Task<ActionResult> Edit(int userId, ProfileVM profile, IFormFile? imageFormFile, IFormFile? imageFormFile2)
        {
 
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await UserManager.GetUserAsync(User);

                    if (!string.IsNullOrEmpty(profile.OldPassword) && !string.IsNullOrEmpty(profile.CurrentPassword))
                    {
                        var changePasswordResult = await UserManager.ChangePasswordAsync(user, profile.OldPassword, profile.CurrentPassword);

                        if (!changePasswordResult.Succeeded)
                        {
                            foreach (var error in changePasswordResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            return View(profile);
                        }
                    }

                        if (imageFormFile != null)
                        {
                            if (profile.Image != "\\imagesUser\\No_image_available.svg.png")
                            {
                                string oldImgFullPath = _webHostEnvironment.WebRootPath + profile.Image;
                            if (System.IO.File.Exists(oldImgFullPath))
                            {
                                System.IO.File.Delete(oldImgFullPath);
                            }

                            }

                            string imgExtension = Path.GetExtension(imageFormFile.FileName);
                            Guid imgGuid = Guid.NewGuid();
                            string imgName = imgGuid + imgExtension;
                            string imgPath = "\\imagesUser\\" + imgName;
                            profile.Image = imgPath;
                            string imgFullPath = _webHostEnvironment.WebRootPath + imgPath;

                            FileStream imgFileStream = new FileStream(imgFullPath, FileMode.Create);
                            imageFormFile.CopyTo(imgFileStream);
                            imgFileStream.Dispose();
                        }

                    if (imageFormFile2 != null)
                    {
                        if (profile.Seller.Logo != "\\Logo\\No_image_available.svg.png")
                        {
                            string oldImgFullPath = _webHostEnvironment.WebRootPath + profile.Seller.Logo;
                            if (System.IO.File.Exists(oldImgFullPath))
                            {
                                System.IO.File.Delete(oldImgFullPath);
                            }

                        }

                        string imgExtension2 = Path.GetExtension(imageFormFile2.FileName);
                        Guid imgGuid2 = Guid.NewGuid();
                        string imgName2 = imgGuid2 + imgExtension2;
                        string imgPath2 = "\\Logo\\" + imgName2;
                        profile.Seller.Logo = imgPath2;
                        string imgFullPath2 = _webHostEnvironment.WebRootPath + imgPath2;

                        FileStream imgFileStream2 = new FileStream(imgFullPath2, FileMode.Create);
                        imageFormFile2.CopyTo(imgFileStream2);
                        imgFileStream2.Dispose();
                    }

                    // Update profile
                    _profileRepo.UpdateProfile(profile);


                    // Redirect to profile index
                    return RedirectToAction(nameof(Index), new { userId = profile.UserId });
                }
                catch (Exception ex)
                {
                    // Log the exception
                    ModelState.AddModelError("", $"An error occurred while updating the profile: {ex.Message}");
                }
            }

            // If ModelState is not valid, return the view with validation errors
            return View(profile);
        }
    }
}


