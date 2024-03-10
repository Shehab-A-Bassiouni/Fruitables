using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitablesDAL;
using FruitablesDAL.Models;
using Microsoft.Extensions.Configuration;

namespace FruitablesBL.EntityManagement.ShopManager
{
    public static class ShopManage
    {
        public static List<Seller> Sellers=new();
        public static List<Product>? Products = new();
        public static void LoadSellers() {
            using (FRUITABLESContext context = new())
            {
                Sellers = context.Sellers.ToList();
            }
        }

        public static void LoadProducts()
        {
            using (FRUITABLESContext context = new())
            {
                Products = context.Products.ToList();
            }
        }

        public static List<List<string>> GetShops() {
            List<List<string>> shopsData = new();
            foreach (Seller seller in Sellers) {
                List<string> temp = new();
                temp.Add(seller.CommercialName);
                temp.Add(seller.Address);
                temp.Add(seller.Logo);

                shopsData.Add(temp);
            }
            return shopsData;
        }

        public static List<List<string>>? GetProductsData(string shopName) {
            int? sellerID = Sellers?.FirstOrDefault(seller => seller.CommercialName == shopName)?.SellerId;
            List<List<string>> sellerProducts = new();
            foreach (Product prod in Products) {
                List<string> temp = new();
                if (prod.SellerId == sellerID) {
                    temp.Add(prod.Name);
                    temp.Add(prod.Description);
                    temp.Add(prod.Price.ToString());
                    sellerProducts.Add(temp);
                }
            }

            return sellerProducts;
        }
    }
}
