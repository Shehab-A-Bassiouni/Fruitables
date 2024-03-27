using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{
    public class ManageOrderVM
    {
        public int OrderId { get; set; }

        public int State { get; set; }

        public DateTime Date { get; set; }

        public bool ShippingState { get; set; }

        public decimal TotalPrice { get; set; }

        public string OrderName { get; set; }

        public int CustomerId { get; set; }

        public decimal ShippingFees { get; set; }

        public virtual Customer Customer { get; set; }

        public List<Item>? Items { get; set; }


    }
}
