using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{
    public class CartItemVM
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemTotalPrice { get; set; }
        public string? ItemImage { get; set; }
        public int ProductID { get; set; }
        public decimal Offer { get; set; }
    }
}
