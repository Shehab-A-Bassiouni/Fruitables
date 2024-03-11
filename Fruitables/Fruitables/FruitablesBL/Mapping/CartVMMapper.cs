using FruitablesBL.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class CartVMMapper
    {
        string ItemName;
        decimal ItemPrice;
        int ItemQuantity;
        decimal TotalPrice;
        string ItemImage;

        public CartVMMapper(List<string> itemData) {
            ItemName = itemData[0];
            decimal.TryParse(itemData[1], out ItemPrice);
            int.TryParse(itemData[2], out ItemQuantity);
            decimal.TryParse(itemData[3], out TotalPrice);
            ItemImage = itemData[4];
        }

        public CartVM ToCartVM() {
            CartVM cartVM = new CartVM
            {
                ItemName=this.ItemName,
                ItemPrice = this.ItemPrice,
                ItemQuantity = this.ItemQuantity,
                TotalPrice = this.TotalPrice,
                ItemImage = this.ItemImage
            };

            return cartVM;
        }

       
    }
}
