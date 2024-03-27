using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{

    //this class is a view model for seller entity
    public class ProductVM
    {
        public int ProductId { get; set; }
        public Offer? offer { get; set; }
        public string Description { get; set; }

        public decimal Rate { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        public string Image { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();

        public virtual Seller Seller { get; set; }

        public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
        public FruitData? fruitData { get; set; }

    }

    public class ProductListVM
    {
        public decimal MaxPrice { get; set; }
        public int Count { get; set; }
        public List<ProductVM> prodsVMS { get; set; } = new List<ProductVM>();
    }
}
