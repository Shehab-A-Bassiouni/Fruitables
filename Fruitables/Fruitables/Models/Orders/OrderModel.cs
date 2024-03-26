using FruitablesBL.EntityManagement.Repository;
using FruitablesBL.Mapping;
using FruitablesBL.ViewModels;
using FruitablesDAL.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Fruitables.Models.Orders
{
    public class OrderModel
    {
        private readonly IMemoryCache memoryCache;
        private readonly FRUITABLESContext context;
        private int UserID;
        private string CartKey;
        private OrderRepo orderRepo;
        private ItemMapper itemMapper;

        public OrderModel(IMemoryCache _memoryCache, FRUITABLESContext _context, int _UserID)
        {
            memoryCache = _memoryCache;
            context = _context;
            UserID = _UserID;
            CartKey = "Cart_" + UserID.ToString();
            orderRepo = new(context);
            itemMapper = new();
        }

        public List<OrderVM> GetFinishedOrders()
        {
            return orderRepo.GetFinishedOrders(UserID);

        }

        public List<OrderVM> GetNotFinishedOrders()
        {
            return orderRepo.GetNotFinishedOrders(UserID);

        }

        public bool DeleteUnfinished(int orederID) {

            User user = context.Users.Find(UserID);
            if (user == null)
            {
                return false;
            }

            Order order =context.Orders.Find(orederID);

            if (order == null)
            {
                return false;
            }

            order.IsActive = false;
            context.SaveChanges();
            return true;
        }

        public List<ItemVM> GetOrderItems(int orderID) {

            List<ItemVM> items = new();
            Order order = context.Orders.Find(orderID);
            List<Item> OrderItems = context.Items.Where(x => x.OrderId == orderID).ToList();

            if (order == null) { 
                return items;
            }

            foreach (Item item in OrderItems) {
                string Name = context.Products.Find(item.ProductId).Name;
                string Image = context.Products.FirstOrDefault(x => x.ProductId == item.ProductId).Image;
                items.Add(itemMapper.setItemVM(item.ItemId, Name, item.Quantity, item.SubTotalPrice, item.ProductId, Image));
            }
            return items;
        }
    }
}
