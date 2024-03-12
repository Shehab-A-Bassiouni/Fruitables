using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class CartVMMapper
    {
        public CartVM? SetItemsValues(int _itemID, string? _itemName, decimal _itemPrice,  string? _itemImage)
        {
            try
            {
                CartVM cartVM = new()
                {
                    ItemID = _itemID,
                    ItemName = _itemName,
                    ItemPrice = _itemPrice,
                    ItemImage = _itemImage,
                };
                return cartVM;
            }

            catch(Exception e) {
                Debug.WriteLine(e.Message);
                return null;
            }
          
        }


    }
}
