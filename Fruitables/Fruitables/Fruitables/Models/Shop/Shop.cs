using BL_ShopManager = FruitablesBL.EntityManagement.ShopManager.ShopManage;
namespace Fruitables.Models.Shop
{
    public class Shop
    {
        public Shop() {
            BL_ShopManager.LoadSellers();
            BL_ShopManager.LoadProducts();
        }

        public List<List<string>>? GetShops() {
            return BL_ShopManager.GetShops();
        }

        public List<List<string>>? GetItems(string shopName)
        {
            return BL_ShopManager.GetProductsData(shopName);
        }
    }
}
