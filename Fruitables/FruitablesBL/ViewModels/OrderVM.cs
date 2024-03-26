using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{
    public class OrderVM
    {
        public int ID { get; set; }
        public string OrderName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public bool ShippingState { get; set; }
        public int State { get; set; }

        public List<ItemVM> Items { get; set; }
    }
}
