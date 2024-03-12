using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{
    public class CartVM
    {
        public int ItemID { get; set; }

        public string? ItemName { get; set; }
        public decimal ItemPrice { get; set; }

        public int ItemQuantity { get; set; }

        public decimal TotalPrice { get; set; }
        public string? ItemImage { get; set; }
        public int CustomerID { get; set; }

    }
}
