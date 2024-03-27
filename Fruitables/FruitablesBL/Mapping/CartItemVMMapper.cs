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
    public class CartItemVMMapper
    {
        public CartItemVM? SetCartItem(int _itemID, string _itemName, decimal _itemPrice, int _itemQuantity, decimal _itemTotalPrice , string _itemImage , decimal _offer , int _ProductID)
        {
            return new CartItemVM
            {
                ItemID = _itemID,
                ItemName = _itemName,
                ItemPrice = _itemPrice,
                ItemQuantity = _itemQuantity,
                ItemTotalPrice = _itemTotalPrice,
                ItemImage = _itemImage,
                Offer = _offer,
                ProductID = _ProductID
                };
        }
    }
}
