using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.Mapping
{
    public class ManageOrderVMMapper
    {
        public ManageOrderVM MapManageOrderVm(Order order)
        {
            return new ManageOrderVM
            {
                OrderId = order.OrderId,
                State = order.State,
                Date = order.Date,
                TotalPrice = order.TotalPrice,
                ShippingFees = order.ShippingFees,
                OrderName = order.OrderName,
                CustomerId = order.CustomerId,
                ShippingState = order.ShippingState,
                Customer = order.Customer,
                Items = (List<Item>)order.Items,
            };

        }
    }
}
