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
        public static List<Seller> allSellers=new();
        public static void LoadSellers() {
            using (FRUITABLESContext context = new())
            {
                allSellers = context.Sellers.ToList();
            }
        }
        public static List<string> GetShopNames() {
            List<string> shopNames = new();
            foreach (Seller seller in allSellers) {
                shopNames.Add(seller.CommercialName);
            }
            return shopNames;
        }
    }
}
