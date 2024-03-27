using FruitablesBL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class ItemMapper
    {

        public ItemVM setItemVM(int _id , string _name , int _quantity , decimal _totalPrice , int _productID , string image) { 
            return new ItemVM() { 
                ID = _id ,  
                Name = _name ,
                Quantity = _quantity ,
                TotalPrice = _totalPrice ,
                ProductID = _productID ,
                Image = image
            };
        
        }
    }
}
