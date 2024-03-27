using FruitablesBL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class CartVmMapper
    {
        public CartVm setCart(int _customerID, List<CartItemVM> cartItems)
        {
            return new CartVm
            {
                CustomerID = _customerID,
                CartItems = cartItems
            };
        }
    }
}
