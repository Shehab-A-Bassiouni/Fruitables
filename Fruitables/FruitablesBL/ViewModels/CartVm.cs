using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{
    public class CartVm
    {
        public int CustomerID { get; set; }
        public List<CartItemVM> CartItems { get; set; }


    }
}
