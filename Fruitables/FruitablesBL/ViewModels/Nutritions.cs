using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.ViewModels
{
    public class FruitData
    {
        public string name { get; set; }
        public int id { get; set; }
        public string family { get; set; }
        public string order { get; set; }
        public string genus { get; set; }
        public Nutritions nutritions { get; set; }


    }
    public class Nutritions
    {
        public decimal calories { get; set; }
        public decimal fat { get; set; }
        public decimal sugar { get; set; }
        public decimal carbohydrates { get; set; }
        public decimal protein { get; set; }
    }
}
