using FruitablesBL.EntityManagement.Repository;
using FruitablesBL.EntityManagement.Interface;
using FruitablesDAL.Models;
using Microsoft.EntityFrameworkCore;
using FruitablesBL.Mapping;
using Microsoft.AspNetCore.Identity;
using Stripe;
using EmailService;
using FruitlessBL.EntityManagement.Interface;
using FruitlessBL.EntityManagement.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Fruitables
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews()
          .AddJsonOptions(options =>
          {
              options.JsonSerializerOptions.PropertyNamingPolicy = null; // Disable camelCase conversion
          });

            // Add services to the container.
           
            builder.Services.AddMemoryCache();
            
            
            
            
           
            builder.Services.AddScoped<HttpClient>();

           
            
            
            builder.Services.AddScoped<IFeedBackRepo, FeedbackRepo>();
            builder.Services.AddScoped<IAccountRepo, AccountRepo>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ProductVMMapper>();
            builder.Services.AddScoped<IproductRepo, ProductRepo>();
            builder.Services.AddScoped<ProfileVMMapper>();
            builder.Services.AddScoped<InterProfileRepo, ProfileRepo>();
            builder.Services.AddScoped<IDashboardrepo, DashboardRepo>();
            builder.Services.AddScoped<IManageSellerRepo, ManageSellerRepo>();
            builder.Services.AddScoped<IOfferRepo, OfferRepo>();
            builder.Services.AddScoped<OfferMapper>();
            builder.Services.AddScoped<ISellerRepo, SellerRepo>();
            builder.Services.AddScoped<CategoryVMMapper>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<ManageOrderVMMapper>();
            builder.Services.AddScoped<IOrder, OrderRepo>();





            builder.Services.AddDbContext<FRUITABLESContext>(op =>
             op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
             );

            builder.Services.AddDbContext<AccountContext>(op =>
           op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           );

            //External Login for Microsoft
            builder.Services.AddAuthentication().AddMicrosoftAccount(options =>
            {
                options.ClientId = builder.Configuration["MicrosoftClientId"];
                options.ClientSecret = builder.Configuration["MicrosoftSecretId"];
            });

            builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, op =>
            {
                op.LoginPath = "/ExternalLogin/login";
                op.AccessDeniedPath = "/ExternalLogin/login";
            });

            //External Login for Google
            builder.Services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["GoogleClientId"];
                options.ClientSecret = builder.Configuration["GoogleSecretId"];
            });

            //External Login for Facebook
            builder.Services.AddAuthentication().AddFacebook(op =>
            {
                op.ClientId = builder.Configuration["FacebookClientId"];
                op.ClientSecret = builder.Configuration["FacebookSecretId"];
            });



            //Identity (Login) Configs.
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                            .AddEntityFrameworkStores<AccountContext>()
                             .AddDefaultTokenProviders();

            //MailService Configuration
            var emailConfig = builder.Configuration
                                            .GetSection("EmailConfiguration")
                                            .Get<EmailConfiguration>();
            builder.Services.AddSingleton(emailConfig);

            builder.Services.AddScoped<IEmailSender, EmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

            app.UseAuthentication();
            app.UseAuthorization();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
