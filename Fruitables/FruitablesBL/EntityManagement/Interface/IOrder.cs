using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Interface
{
    public interface IOrder
    {

        public List<OrderVM> GetFinishedOrders(int CustomerID);
        public List<OrderVM> GetNotFinishedOrders(int CustomerID);
        public List<ManageOrderVM> GetAllOrdersForSeller(int sellerId);
        public void UpdateShippingState(int orderId, bool newShippingState);



    }
}
