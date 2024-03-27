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
    public class CartRepo //: //ICartRepo
    {
        private readonly FRUITABLESContext DbContext;
        private readonly CartItemVMMapper ItemMapper;
        public CartRepo()
        {
            DbContext = new();
            ItemMapper = new();
        }

        public bool AddItem_ToCart(CartItemVM cartItem, CartVm cart) {
            cart.CartItems.Add(cartItem);
            return true;
        }

        public string[] CartToJson(CartVm cart) {
            string key = "Cart" + cart.CustomerID.ToString();
            string value = JsonConvert.SerializeObject(cart);
            return [key, value];
        }

        public CartItemVM GetItemData_FromItemID(int _itemID) {
            Product product = DbContext.Products.FirstOrDefault(item => item.ProductId == _itemID);
            Offer offer = product.Offers.FirstOrDefault(x => x.IsActive == true && x.ExpireDate >= DateTime.Now);
            decimal currentOffer = 0;
            if (offer != null) {
                currentOffer = offer.Discount;
            }
            CartItemVM item = ItemMapper.SetCartItem(product.ProductId ,product.Name, product.Price,1,product.Price,$"{product.ProductId}.jpg", currentOffer, product.ProductId);
            return item;
        }

      
    }
}
