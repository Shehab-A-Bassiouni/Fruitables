using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{

    //this class is a view model for seller entity
    public class SellerVM
    {
        
        public int SellerId { get; set; }

        public string CommercialName { get; set; }

        public decimal Rate { get; set; }

        public string Address { get; set; }

        public string Logo { get; set; }

        public List<SellerVM> SellerList { get; set; } = new List<SellerVM>();

    }

    public class SellerListVM
    {
        public int Count { get; set; }
        public List<SellerVM> selerVMS { get; set; }   = new List<SellerVM>();
    }

}
