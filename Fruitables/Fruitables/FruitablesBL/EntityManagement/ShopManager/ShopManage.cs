using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FruitablesDAL;
using FruitablesDAL.Models;
using Microsoft.Extensions.Configuration;

namespace FruitablesBL.EntityManagement.ShopManager
{
    public static class ShopManage
    {
        public static List<Seller>? Sellers=new();
        public static List<Product>? Products = new();

        
        public static void LoadSellers() {
            try {
                using (FRUITABLESContext context = new())
                {
                    Sellers = context.Sellers.ToList();
                }
            }

            catch (Exception e) { 
                Debug.WriteLine(e.Message);

            }

        }

        public static void LoadProducts()
        {
            try
            {
                using (FRUITABLESContext context = new())
                {
                    Products = context.Products.ToList();
                }
            }
            catch (Exception e){
                Debug.WriteLine(e.Message);
            }
            
        }

        public static List<List<string>>? GetShopNames() {
            if (Sellers is null)
                LoadSellers();


            List<List<string>> shops = new();

            if (Sellers is null)
                return null;

            foreach (Seller? seller in Sellers) {
                List<string> temp = new();
                temp.Add(seller.Logo); 
                temp.Add(seller.CommercialName);
                temp.Add(seller.Address);
                shops.Add(temp);
            }

            return shops;
        }

        public static List<string>? GetItemsForShop(string shopName) {
            if (Products is null)
                LoadProducts();

            List<string>? products = new();

            Seller? oneSeller = Sellers?.FirstOrDefault(seller => seller.CommercialName == shopName);

            if (oneSeller is not null)
            {
                if (Products is null)
                    return null;

                foreach (Product? prod in Products)
                {
                    products.Add(prod.Name);
                    products.Add(prod.Description);
                    products.Add(prod.Price.ToString());
                }
            }

            else {
                LoadSellers();
                oneSeller = Sellers?.FirstOrDefault(seller => seller.CommercialName == shopName);
            }

            if (oneSeller is null)
                return null;


            return products;

        }
    }
}
