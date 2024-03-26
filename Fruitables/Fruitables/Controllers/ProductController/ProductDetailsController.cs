using Fruitables.Models.CartModel;
using FruitablesBL.EntityManagement.Interface;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Fruitables.Controllers.ProductController
{
    public class ProductDetailsController : Controller
    {
        private readonly IMemoryCache memoryCache;
        private readonly FRUITABLESContext context;
        private readonly IproductRepo productRep;

        public ProductDetailsController(IMemoryCache _memoryCache, FRUITABLESContext _context, IproductRepo prdRepo)
        {
            memoryCache = _memoryCache;
            context = _context;
            productRep = prdRepo;


        }

        public async Task<IActionResult> Details(int productID)
        {
            var product = productRep.getProdDetais(productID);

            return View(await product);
        }
    }
}
