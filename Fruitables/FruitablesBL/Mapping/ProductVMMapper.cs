using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class ProductVMMapper
    {
        public static Product MapToProduct(ManageProductVM productVM)
        {
            return new Product
            {
                Description = productVM.Description,
                Stock = productVM.Stock,
                Rate = productVM.Rate,
                Name = productVM.Name,
                Price = productVM.Price,
                CostPrice = productVM.CostPrice,
                CategoryId = productVM.CategoryId,
                SellerId = productVM.SellerId,
                Image = productVM.Image
            };
        }

        public ManageProductVM MapToManageProductVM(Product product)
        {

            return new ManageProductVM
            {
                ProductId = product.ProductId,
                Description = product.Description,
                Stock = product.Stock,
                Rate = product.Rate,
                Name = product.Name,
                Price = product.Price,
                CostPrice = product.CostPrice,
                CategoryId = product.CategoryId,
                SellerId = product.SellerId,
                Image = product.Image,
                CategoryName = product.Category.Name,
                IsActive = product.IsActive ? 1 : 0,
            };
        }


        public static Product MapProductIdToProduct(int productId, FRUITABLESContext dbContext)
        {
            return dbContext.Products.SingleOrDefault(p => p.ProductId == productId);
        }



    }
}
