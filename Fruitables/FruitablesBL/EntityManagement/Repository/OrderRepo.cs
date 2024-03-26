using FruitablesBL.EntityManagement.Interface;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitablesBL.EntityManagement.Repository
{
    public class OrderRepo :IOrder
    {
        private readonly FRUITABLESContext context;
        private OrderVMMapper orderVMMapper;
        private ItemMapper itemMapper;
        private readonly ManageOrderVMMapper manageorderVMMapper;



        public OrderRepo(FRUITABLESContext _context) {
            context = _context;
            manageorderVMMapper = new ManageOrderVMMapper();
            itemMapper = new ItemMapper();
            orderVMMapper = new OrderVMMapper();
        }

        // State 1 => Getting Ready
        // State 2 => On Way
        // State 3 => Shipped
        public List<OrderVM> GetFinishedOrders(int CustomerID) { 
            List<Order> orders = context.Orders.Where(x => x.CustomerId == CustomerID && x.ShippingState == true && x.IsActive == true).ToList();
            List<OrderVM> ordersVMs = new List<OrderVM>();

            foreach (Order order in orders) {
                List<ItemVM> itemsVM = new List<ItemVM>();
                foreach (Item item in order.Items) {
                    string Image = context.Products.FirstOrDefault(x => x.ProductId == item.ProductId).Image;
                    itemsVM.Add(itemMapper.setItemVM(item.ItemId,item.Product.Name,item.Quantity,item.SubTotalPrice,item.Product.ProductId , Image));
                }
               var tmp = orderVMMapper.SetOrderVM(order.OrderId, order.OrderName, order.TotalPrice, order.Date, order.ShippingState,order.State, itemsVM);
                ordersVMs.Add(tmp);
            }
            return ordersVMs;
        }

        public List<OrderVM> GetNotFinishedOrders(int CustomerID)
        {
            List<Order> orders = context.Orders.Where(x => x.CustomerId == CustomerID && x.ShippingState==false && x.IsActive == true).ToList();
            List<OrderVM> ordersVMs = new List<OrderVM>();

            foreach (Order order in orders)
            {
                List<ItemVM> itemsVM = new List<ItemVM>();
                foreach (Item item in order.Items)
                {
                    string Image = context.Products.FirstOrDefault(x => x.ProductId == item.ProductId).Image;

                    itemsVM.Add(itemMapper.setItemVM(item.ItemId, item.Product.Name, item.Quantity, item.SubTotalPrice, item.Product.ProductId, Image));
                }
                var tmp = orderVMMapper.SetOrderVM(order.OrderId, order.OrderName, order.TotalPrice, order.Date, order.ShippingState, order.State, itemsVM);
                ordersVMs.Add(tmp);
            }
            return ordersVMs;
        }

        public List<ManageOrderVM> GetAllOrdersForSeller(int sellerId)
        {
            // Retrieve all orders for the given sellerId from the database
            var orders = (from order in context.Orders
                          join item in context.Items on order.OrderId equals item.OrderId
                          join product in context.Products on item.ProductId equals product.ProductId 
                          where  order.IsActive && product.SellerId == @sellerId
                          select  new
                          {
                              Order = order,
                              Item = item
                          }).ToList();

            // Group orders by order ID and map them to ManageOrderVM using the mapper
            var manageordersVMs = orders.GroupBy(o => o.Order.OrderId)
                                        .Select(g => new ManageOrderVM
                                        {
                                            OrderId = g.Key,
                                            State = g.First().Order.State,
                                            Date = g.First().Order.Date,
                                            TotalPrice = g.First().Order.TotalPrice,
                                            ShippingFees = g.First().Order.ShippingFees,
                                            OrderName = g.First().Order.OrderName,
                                            CustomerId = g.First().Order.CustomerId,
                                            ShippingState = g.First().Order.ShippingState,
                                            Customer = g.First().Order.Customer,
                                            
                                        }).ToList();

            return manageordersVMs;
        }


        public void UpdateShippingState(int orderId, bool newShippingState)
        {
            Order order = context.Orders.FirstOrDefault(x => x.OrderId == orderId);
            if (order != null)
            {
                order.ShippingState = newShippingState;
                context.SaveChanges();
            }
        }




    }
}
