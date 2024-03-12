using FruitablesBL.EntityManagement.Repository;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Diagnostics;
namespace Fruitables.Models.Cart
{
    public static class Cart {
        public static List<CartVM>? CurrentCart = new();

      
        public static bool AddToCart(int _itemID) {

            try
            {
                CartRepo cartRepo = new();
                CurrentCart!.Add(cartRepo!.GetItemByID(_itemID)??new CartVM());
                return true;
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
                return false;
            }



        }
     
    }
}
