using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Repository
{
    public class CartRepo : ICartRepo
    {
     

        private readonly FRUITABLESContext? DbContext;

        public CartRepo() {
            DbContext = new();
        }

        public CartVM? GetItemByID(int _itemID) {

            try {
                Product product = DbContext!.Products.First(item => item.ProductId == _itemID);
                CartVMMapper cartVMMapper = new();
                return cartVMMapper.SetItemsValues(
                    product.ProductId,
                    product.Name,
                    product.Price,
                    0,
                    product.Price,
                    "",
                    2
                    );
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
                return null;
            }
          
        }


      
    }
}
