using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class OrderVMMapper
    {
        public OrderVM SetOrderVM(int _ID , string _OrderName, decimal _TotalPrice , DateTime _OrderDate , bool _ShippingState , int _State , List<ItemVM> _Items) {
             return  new OrderVM
            {
                ID = _ID ,
                OrderName = _OrderName ,  
                TotalPrice = _TotalPrice ,
                OrderDate = _OrderDate ,
                ShippingState = _ShippingState ,
                State = _State ,
                Items = _Items
            };    
        
        }
    }
}
