using EmailService;
using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Fruitables.Controllers.AccountController
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> UserManager {  get; set; }

        public SignInManager<IdentityUser> SignInManager {  get; set; }

        public RoleManager<IdentityRole> RoleManager { get; set; }

        public readonly IEmailSender _emailSender;

        public IAccountRepo IAccount { get; }
        public AccountController(SignInManager<IdentityUser> signInManager , UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IAccountRepo Iaccount, IEmailSender emailSender)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            RoleManager = roleManager;
            IAccount = Iaccount;
            _emailSender = emailSender;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Register(RegisterVM newUserVM)
        {
            if(ModelState.IsValid) 
            {
                IdentityUser userModel = new IdentityUser();
                userModel.UserName = newUserVM.UserName;
                userModel.Email = newUserVM.Email;
                userModel.PhoneNumber = newUserVM.PhoneNumber;
                userModel.PasswordHash = newUserVM.Password;

                IdentityResult result =  await UserManager.CreateAsync(userModel,newUserVM.Password);
                Global.Global.User = userModel;
                if(result.Succeeded)
                {
                    if (!await RoleManager.RoleExistsAsync(newUserVM.UserType.ToString()))
                    {
                        await RoleManager.CreateAsync(new IdentityRole(newUserVM.UserType.ToString()));
                    }

                    User NewUser = UserIdentityUserMapper.IdentityUserToUser(userModel);
                    IAccount.AddInUsers(NewUser);

                    // Add user to role
                    await UserManager.AddToRoleAsync(userModel, newUserVM.UserType.ToString());

                    if (newUserVM.UserType.ToString() == "Seller")
                    {
                        Seller NewSeller = UserIdentityUserMapper.IdentityUserToSeller(NewUser);
                        IAccount.AddinSellers(NewSeller);

                        await SignInManager.SignInAsync(userModel, isPersistent: false);
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else if (newUserVM.UserType.ToString() == "Customer")
                    {
                        Customer NewCustomer = UserIdentityUserMapper.IdentityUserToCustomer(NewUser);
                        IAccount.AddinCustomers(NewCustomer);

                        await SignInManager.SignInAsync(userModel, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else if (newUserVM.UserType.ToString() == "Admin")
                    {
                        Admin NewAdmin = UserIdentityUserMapper.IdentityUserToAdmin(NewUser);
                        IAccount.AddinAdmins(NewAdmin);

                        await SignInManager.SignInAsync(userModel, isPersistent: false);
                        return RedirectToAction("Index", "Dashboard");

                    }


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("", errorItem.Description);
                    }

                }

            }
            return View(newUserVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM userVM)
        {
            if (ModelState.IsValid) 
            {

                try
                {
                    IdentityUser userLogin = await UserManager.FindByNameAsync(userVM.UserName);
                    if (userLogin != null)
                    {
                        bool Found = await UserManager.CheckPasswordAsync(userLogin, userVM.Password);

                        if (Found)
                        {
                            Global.Global.User = userLogin;
                            await SignInManager.SignInAsync(userLogin, userVM.RememberMe);

                            var Roles = await UserManager.GetRolesAsync(userLogin);

                            if (Roles.Contains("Seller"))
                            {
                                return RedirectToAction("Index", "Dashboard");
                            }
                            else if (Roles.Contains("Customer"))
                            {
                                return RedirectToAction("Index", "Home");
                            }
                            else if (Roles.Contains("Admin"))
                            {
                                return RedirectToAction("Index", "Dashboard");

                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
              
            }

            ModelState.AddModelError("", "Incorrect Username or Password");
            return View(userVM);
        }



        public IActionResult Logout()
        {
            SignInManager.SignOutAsync();
            return RedirectToAction("Register","Account");
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = UserManager.GeneratePasswordResetTokenAsync(user);

                    var PasswordResetLink = Url.Action("ResetPassword", "Account", new { email = model.Email, Token = token.Result }, Request.Scheme);

                    var message = new EmailService.Message(new string[] { model.Email }, "Reset Password"
                        , $"""
                            This is Password Reset Link , if you don't request this link Please Ignore It.
                                {PasswordResetLink}
                          """);
                    await _emailSender.SendEmailAsync(message);

                    return View("ForgotPasswordConfirmation");

                }
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string Token, string email)
        {
            if (Token == null || email == null)
            {
                ModelState.AddModelError("", "Please re-check the link provided in your Email");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await UserManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
                return View("ResetPasswordConfirmation");
            }
            return View(model);
        }
    }
}
