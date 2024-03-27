using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FruitablesBL.EntityManagement.Repository
{
    public class ProductRepo : IproductRepo
    {
        private readonly FRUITABLESContext DbContext;
        private readonly ProductVMMapper _productMapper;
        private readonly ICategoryRepo _categoryRepo;
        private readonly HttpClient _httpClient;

        public ProductRepo(FRUITABLESContext _db, ProductVMMapper productMapper, ICategoryRepo categoryRepo, HttpClient httpClient)
        {
            DbContext = _db;
            _productMapper = productMapper;
            _categoryRepo = categoryRepo;
            _httpClient = httpClient;


        }
        public ProductListVM GetProducts(int categID, int sellerID, decimal maxPrice, string pName, int pageNumber)
        {


            try
            {
                int itemsPerPage = 6;
                int skipped = (pageNumber - 1) * itemsPerPage;

                ProductListVM products = new();
                IEnumerable<Product> allProducts = DbContext.Products.Include(p => p.Category).Include(p => p.Seller).Include(p => p.FeedBacks).Include(p => p.Offers);

                if (categID > 0)
                {
                    Category Categ = DbContext.Categories.Include(c => c.InverseParentCategory).FirstOrDefault(c => c.CategoryId == categID);
                    Console.WriteLine(Categ.Name);
                    if (Categ != null)
                    {
                        List<int> ids = CategoryRepo.GetAllChildCategories(Categ);
                        ids.Add(categID);
                        allProducts = allProducts.Where(p => ids.Contains(p.CategoryId));
                    }

                }

                if (sellerID > 0)
                {
                    allProducts = allProducts.Where(p => p.SellerId == sellerID);
                }
                if (pName != null)
                {
                    allProducts = allProducts.Where(p => p.Name.Contains(pName));
                }


                if (maxPrice > 0)
                {
                    allProducts = allProducts.Where(p => p.Price <= maxPrice);
                }

                products.Count = allProducts.Count();

                foreach (Product prod in allProducts.Skip(skipped).Take(itemsPerPage))
                {


                    ProductVM newProduct = new()
                    {
                        Category = prod.Category,
                        Description = prod.Description,
                        FeedBacks = prod.FeedBacks,
                        Name = prod.Name,
                        Price = prod.Price,
                        Offers = prod.Offers,
                        Rate = prod.Rate,
                        ProductId = prod.ProductId,
                        Seller = prod.Seller,
                        Image = prod.Image,
                    };

                    if (prod.Offers.Any())
                    {
                        Offer offer = prod.Offers.FirstOrDefault(o => o.SellerId == prod.SellerId && o.ExpireDate >= DateTime.Now);
                        if (offer != null)
                        {
                            newProduct.offer = prod.Offers.ToList()[0];
                        }
                        else
                        {
                            newProduct.offer = null;

                        }

                    }
                    else
                    {
                        newProduct.offer = null;
                    }
                    products.prodsVMS.Add(newProduct);
                }

                return products;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return new ProductListVM();
            }
        }





        public void CreateProduct(ManageProductVM productVM)
        {
            var newProduct = Mapping.ProductVMMapper.MapToProduct(productVM);
            newProduct.IsActive = true;
            DbContext.Products.Add(newProduct);
            DbContext.SaveChanges();
        }
        public async Task<ProductVM> getProdDetais(int productId)
        {
            try
            {

                var prod = await DbContext.Products.Include(p => p.Category).Include(p => p.Seller).Include(p => p.FeedBacks).Include(p => p.Offers).FirstOrDefaultAsync(o => o.ProductId == productId);
                if (prod != null)
                {

                    ProductVM newProduct = new()
                    {
                        Category = prod.Category,
                        Description = prod.Description,
                        FeedBacks = prod.FeedBacks,
                        Name = prod.Name,
                        Price = prod.Price,
                        Offers = prod.Offers,
                        Rate = prod.Rate,
                        ProductId = prod.ProductId,
                        Seller = prod.Seller,
                        Image=prod.Image,

                    };

                    if (prod.Offers.Any())
                    {
                        Offer offer = prod.Offers.FirstOrDefault(o => o.SellerId == prod.SellerId && o.ExpireDate >= DateTime.Now);
                        if (offer != null)
                        {
                            newProduct.offer = prod.Offers.ToList()[0];
                        }
                        else
                        {
                            newProduct.offer = null;

                        }

                    }
                    else
                    {
                        newProduct.offer = null;
                    }

                    var response = await _httpClient.GetAsync($"https://www.fruityvice.com/api/fruit/{prod.Name}");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var data = JsonSerializer.Deserialize<FruitData>(json);
                        newProduct.fruitData = data;
                    }
                    else
                    {
                        Debug.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                    }
                    return newProduct;
                }
                else
                {
                    return new ProductVM();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return new ProductVM();
            }
        }

        public ManageProductVM GetProductById(int productId)
        {
            var product = DbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .Include(p => p.FeedBacks)
                .SingleOrDefault(p => p.ProductId == productId);

            if (product != null)
            {

                return _productMapper.MapToManageProductVM(product);
            }

            return null;
        }





        public void DeleteProduct(int productId)
        {
            var product = ProductVMMapper.MapProductIdToProduct(productId, DbContext);

            if (product != null)
            {
                product.IsActive = false;

                DbContext.SaveChanges();
            }
        }

        public IEnumerable<ManageProductVM> GetAllProducts()
        {

            var products = DbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .Include(p => p.FeedBacks)
                .ToList();

            return products.Select(p => _productMapper.MapToManageProductVM(p));
        }
        public IEnumerable<ManageProductVM> GetAllProducts(int sellerId)
        {
            bool IsActive = true;
            var products = DbContext.Products
               .Include(p => p.Category)
               .Include(p => p.Seller)
               .Include(p => p.FeedBacks)
               .Where(p => p.SellerId == sellerId)
               .ToList();

            return products.Select(p => _productMapper.MapToManageProductVM(p));
        }


        public void UpdateProduct(ManageProductVM productVM)
        {
            var existingProduct = DbContext.Products.SingleOrDefault(p => p.ProductId == productVM.ProductId);
            if (existingProduct != null)
            {
                // Map ManageProductVM to Product using mapper
                var updatedProduct = ProductVMMapper.MapToProduct(productVM);

                // Update existing product properties
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Stock = updatedProduct.Stock;
                existingProduct.Rate = updatedProduct.Rate;
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.CostPrice = updatedProduct.CostPrice;
                existingProduct.CategoryId = updatedProduct.CategoryId;
                existingProduct.SellerId = updatedProduct.SellerId;
                existingProduct.Image = updatedProduct.Image;

                DbContext.SaveChanges();
            }
        }
        public ManageProductVM GetProductForEdit(int productId)
        {
            var product = GetProductById(productId);
            var categories = _categoryRepo.GetAllCategories();

            if (product == null)
            {
                return null; // Return null if product not found
            }

            var model = new ManageProductVM
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Stock = product.Stock,
                Rate = product.Rate,
                Price = product.Price,
                CostPrice = product.CostPrice,
                CategoryId = product.CategoryId,
                SellerId = product.SellerId,
                Image = product.Image,
                Categories = categories.Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name }),
            };

            return model;
        }
    }
}
